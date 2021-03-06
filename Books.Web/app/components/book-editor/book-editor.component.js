﻿app.component("bookEditor", {
    templateUrl: '/app/components/book-editor/book-editor.view.html',
    controller: ['$scope', 'bookService', 'localStorageService', bookEditorController]
});

function bookEditorController($scope, bookService, localStorageService) {
    var _saveSortingSettings = function () {
        localStorageService.set('booksSortingSettings', $scope.sortingSettings);
    };

    var _loadSortingSettings = function () {
        $scope.sortingSettings = localStorageService.get('booksSortingSettings');
        if (!$scope.sortingSettings) {
            $scope.sortingSettings = {
                sortByProperty: "title",
                sortInReverseOrder: false
            };
        }
    }

    _loadSortingSettings();

    $scope.sortBy = function (property) {
        if ($scope.sortingSettings.sortByProperty == property) {
            $scope.sortingSettings.sortInReverseOrder = !$scope.sortingSettings.sortInReverseOrder;
        }
        else {
            $scope.sortingSettings.sortInReverseOrder = false;
            $scope.sortingSettings.sortByProperty = property;
        }
        _saveSortingSettings();
    }


    $scope.books = [];

    var createEmptyBook = function () {
        return {
            authors: [{}]
        };
    }

    $scope.editedBook = createEmptyBook();
    $scope.originalEditedBook = null;

    $scope.getBookImageUrl = function (bookId) {
        return bookService.getBookImageUrl(bookId);
    };

    $scope.markImageToRemove = function (book) {
        book.isNeedRemoveImage = true;
    }

    $scope.markImageToNotRemove = function (book) {
        book.isNeedRemoveImage = false;
    }

    $scope.isEditing = function () {
        return $scope.originalEditedBook != null;
    }

    $scope.setEditedBook = function (book) {
        $scope.cancelEditing();

        $scope.editedBook = angular.copy(book);
        $scope.originalEditedBook = book;
    }

    $scope.addEmptyAuthor = function () {
        $scope.editedBook.authors.push({});
    };

    $scope.getControlName = function (name, index) {
        return name + '[' + index + ']'
    };

    $scope.removeAuthor = function (author) {
        var index = $scope.editedBook.authors.indexOf(author);
        $scope.editedBook.authors.splice(index, 1);
    }

    $scope.cancelEditing = function () {
        $scope.editedBook = createEmptyBook();
        $scope.originalEditedBook = null;
        $scope.formEditBook.$setPristine();
        $scope.formEditBook.$setUntouched();
    }
    
    var _showResponseErrorMessage = function (response) {
        var errors = [];
        for (var key in response.data.modelState) {
            for (var i = 0; i < response.data.modelState[key].length; i++) {
                errors.push(response.data.modelState[key][i]);
            }
        }
        alert("Failed due to: " + errors.join(' '));
    };

    $scope.addBook = function () {
        bookService.addBook($scope.editedBook).then(
            function (response) {
                $scope.books.push(response.data);
                $scope.cancelEditing();
            },
            function (response) {
                _showResponseErrorMessage(response);
            }
        );
    };

    $scope.updateBook = function () {
        bookService.updateBook($scope.editedBook).then(
            function (response) {
                var index = $scope.books.indexOf($scope.originalEditedBook);
                angular.extend($scope.books[index], response.data);
                //$scope.books.splice(index, 1, response.data);
                $scope.cancelEditing();
            },
            function (response) {
                _showResponseErrorMessage(response);
            }
        );
    };

    $scope.isCurrentItem = function (bookId) {
        return $scope.isEditing() && $scope.editedBook.id == bookId
    }

    $scope.deleteBook = function () {
        bookService.deleteBook($scope.editedBook.id).then(
            function (response) {
                var index = $scope.books.indexOf($scope.originalEditedBook);
                $scope.books.splice(index, 1);

                $scope.cancelEditing();
            },
            function (response) {
                _showResponseErrorMessage(response);
            }
        );
    };

    bookService.getBooks().then(
        function (response) {
            $scope.books = response.data;
        },
        function () {
            showResponseErrorMessage();
        }
    );
}