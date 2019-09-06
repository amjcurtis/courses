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
	templ, err := template.ParseFiles(tmpl + ".html")
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
		return
	}
	err = templ.Execute(writer, page)
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
	}
}

func saveHandler(writer http.ResponseWriter, request *http.Request) {
	title := request.URL.Path[len("/save/"):]
	body := request.FormValue("body")
	page := &Page{Title: title, Body: []byte(body)}
	page.save()
	http.Redirect(writer, request, "/view/"+title, http.StatusFound)
}

func main() {
	http.HandleFunc("/view/", viewHandler)
	http.HandleFunc("/edit/", editHandler)
	http.HandleFunc("/save/", saveHandler)
	log.Fatal(http.ListenAndServe(":8080", nil))
}
