package main

import (
	"html/template"
	"io/ioutil"
	"log"
	"net/http"
	"regexp"
)

// Define data structure for wiki page
type Page struct {
	Title string
	Body  []byte
}

// Parse all files into single *Template once on initializing program
var templates = template.Must(template.ParseFiles("edit.html", "view.html"))

// Regex to use for path/page title validation
var titleValidator = regexp.MustCompile("^/(edit|save|view)/([a-zA-Z0-9]+)$")

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

func viewHandler(writer http.ResponseWriter, request *http.Request, title string) {
	page, err := loadPage(title)
	if err != nil {
		// Redirect adds 302 StatusFound code and a Location header to http response
		http.Redirect(writer, request, "/edit/"+title, http.StatusFound)
		return
	}
	renderTemplate(writer, "view", page)
}

func editHandler(writer http.ResponseWriter, request *http.Request, title string) {
	page, err := loadPage(title)
	if err != nil {
		page = &Page{Title: title}
	}
	renderTemplate(writer, "edit", page)
}

func saveHandler(writer http.ResponseWriter, request *http.Request, title string) {
	body := request.FormValue("body")
	page := &Page{Title: title, Body: []byte(body)}
	err := page.save()
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
		return
	}
	http.Redirect(writer, request, "/view/"+title, http.StatusFound)
}

func renderTemplate(writer http.ResponseWriter, tmpl string, page *Page) {
	err := templates.ExecuteTemplate(writer, tmpl+".html", page)
	if err != nil {
		http.Error(writer, err.Error(), http.StatusInternalServerError)
	}
}

// Wrapper function for creating handler funcs
func makeHandler(fn func(http.ResponseWriter, *http.Request, string)) http.HandlerFunc {
	return func(writer http.ResponseWriter, request *http.Request) {
		// Extract path/page title from the Request and call the provided handler 'fn'
		titleMatch := titleValidator.FindStringSubmatch(request.URL.Path)
		if titleMatch == nil {
			http.NotFound(writer, request)
			return
		}
		fn(writer, request, titleMatch[2]) // The title is the second subexpression
	}
}

func main() {
	http.HandleFunc("/view/", makeHandler(viewHandler))
	http.HandleFunc("/edit/", makeHandler(editHandler))
	http.HandleFunc("/save/", makeHandler(saveHandler))
	log.Fatal(http.ListenAndServe(":8080", nil))
}
