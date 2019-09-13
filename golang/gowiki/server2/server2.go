package main

import (
	"io/ioutil"
	"log"
	"net/http"
)

func getPage(url string) []byte {
	resp, err := http.Get(url)
	if err != nil {
		log.Fatal(err)
	}
	defer resp.Body.Close()
	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		log.Fatal(err)
	}
	return body
}

func main() {
	http.HandleFunc("/ping/", func(writer http.ResponseWriter, _ *http.Request) {
		body := getPage("http://wikiserver:8080/view/test")
		_, err := writer.Write(body)
		if err != nil {
			log.Fatal(err)
		}
	})
	log.Fatal(http.ListenAndServe(":8081", nil))
}
