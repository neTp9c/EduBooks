app.factory("bookService", ['$http', 'bookEditorSettings', 'Upload', function ($http, bookEditorSettings, Upload) {
    
    var bookServiceFactory = {};

    var _baseUrl = bookEditorSettings.apiBaseUri + 'books';
    var _getUrl = function(bookId) { 
        return _baseUrl + '/' + bookId;
    }

    var _addBook = function (book) {
        return Upload.upload({
            url: _baseUrl,
            data: book,
            objectKey: '.k',
            arrayKey: '[i]'
        });
    };

    var _updateBook = function (book) {
        return Upload.upload({
            url: _getUrl(book.id),
            data: book,
            objectKey: '.k',
            arrayKey: '[i]'
        });
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