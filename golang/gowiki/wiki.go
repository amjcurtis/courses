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
	page, _ := loadPage(title)
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
	templ, _ := template.ParseFiles(tmpl + ".html")
	templ.Execute(writer, page)
}

func main() {
	http.HandleFunc("/view/", viewHandler)
	http.HandleFunc("/edit/", editHandler)
	// http.HandleFunc("/save/", saveHandler)
	log.Fatal(http.ListenAndServe(":8080", nil))
}
