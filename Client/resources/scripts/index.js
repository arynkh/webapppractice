function getBooks(){
    const allBooksApiUrl =  "https://localhost:5001/api/books";

        fetch(allBooksApiUrl).then(function(response){
        console.log(response); //writes the function response to the console
        return response.json(); //method that turns the response into a json object (into something we can deal with).

    }).then(function(json){
        let html = "<ul>";
        json.forEach((book)=>{
            html += "<li>" + book.title + " written by " + book.author + "</li>";
        });
        html += "</ul>";
        document.getElementById("books").innerHTML = html;

    }).catch(function(error){
        console.log(error); //logs any errors that are caught
    });
}

function postBook(){
    const postBookApiUrl = "https://localhost:5001/api/books";
    const bookTitle = document.getElementById("title").value;
    const bookAuthor = document.getElementById("author").value;

    //"we need to update a few things and let you know about it"
    // the second input (behind comma is an object)
    fetch(postBookApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            Title: bookTitle,
            Author: bookAuthor
        })
    })
    .then((response) =>{
        console.log(response);
        getBooks();
    })
}