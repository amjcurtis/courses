package main

import (
	"html/template"
	"io/ioutil"
	"log"
	"net/http"
)

// Define data structure for wiki page
type Page struct {
	Title string
	Body  []byte
}

// Parse all files into single *Template once on initializing program
var templates = template.Must(template.ParseFiles("edit.html", "view.html"))

// Method for persisting page data by saving as text file
func (page *Page) save() error {
	filename := page.Title + ".txt"
	return ioutil.WriteFile(filename, page.Body, 0600)
}

// Constructs filename from title param, reads file, and returns wiki page
func loadPage(title string) (*Page, error) {
	filename := title + ".txt"
	body, err := ioutil.ReadFile(filename)
	if err != nil {
		return nil, err
	}
	return &Page{Title: title, Body: body}, nil
}

func viewHandler(writer http.ResponseWriter, request *http.Request) {
	title := request.URL.Path[len("/view/"):]
	page, err := loadPage(title)
	if err != nil {
		// Redirect adds 302 StatusFound code and a Location header to http response
		http.Redirect(writer, request, "/edit/"+title, http.StatusFound)
		return
	}
	renderTemplate(writer, "view", page)
}

func editHandler(writer http.ResponseWriter, request *http.Request) {
	title := request.URL.Path[len("/edit/"):]
	page, err := loadPage(title)
	if err != nil {
		page = &Page{Title: title}
	}
	renderTemplate(writer, "edit", page)
}

func renderTemplate(writer http.ResponseWriter, tmpl string, page *Page) {
	err := templates.ExecuteTemplate(writer, tmpl+".html", page)
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
	}
}

func saveHandler(writer http.ResponseWriter, request *http.Request) {
	title := request.URL.Path[len("/save/"):]
	body := request.FormValue("body")
	page := &Page{Title: title, Body: []byte(body)}
	err := page.save()
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
		return
	}
	http.Redirect(writer, request, "/view/"+title, http.StatusFound)
}

func main() {
	http.HandleFunc("/view/", viewHandler)
	http.HandleFunc("/edit/", editHandler)
	http.HandleFunc("/save/", saveHandler)
	log.Fatal(http.ListenAndServe(":8080", nil))
}
