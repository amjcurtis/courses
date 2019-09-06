package main

import (
	"fmt"
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
	fmt.Fprintf(writer, "<h1>%s</h1><div>%s</div>", page.Title, page.Body)
}

func main() {
	http.HandleFunc("/view/", viewHandler)
	log.Fatal(http.ListenAndServe(":8080", nil))
}
