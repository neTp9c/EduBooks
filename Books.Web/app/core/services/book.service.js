app.factory("bookService", ['$http', "bookEditorSettings", function ($http, bookEditorSettings) {
    
    var bookServiceFactory = {};

    var _baseUrl = bookEditorSettings.apiBaseUri + 'books';
    var _getUrl = function(bookId) { 
        return _baseUrl + '/' + bookId;
    }

    var _addBook = function (book) {
        return $http.post(_baseUrl, book);
    };

    var _updateBook = function (book) {
        return $http.put(_getUrl(book.id), book);
    }

    var _deleteBook = function (bookId) {
        return $http.delete(_getUrl(bookId));
    }

    var _getBooks = function () {
        return $http.get(_baseUrl);
    }

    var _getBook = function (bookId) {
        return $http.get(_getUrl(bookId));
    }

    bookServiceFactory.addBook = _addBook;
    bookServiceFactory.updateBook = _updateBook;
    bookServiceFactory.deleteBook = _deleteBook;
    bookServiceFactory.getBook = _getBook;
    bookServiceFactory.getBooks = _getBooks;

    return bookServiceFactory;
}]);