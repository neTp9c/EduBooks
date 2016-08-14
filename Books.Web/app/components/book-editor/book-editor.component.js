app.component("bookEditor", {
    templateUrl: '/app/components/book-editor/book-editor.view.html',
    controller: ['$scope', 'bookService', bookEditorController]
});

function bookEditorController($scope, bookService) {
    $scope.books = [];

    bookService.getBooks().then(
        function (response) {
            $scope.books = response.data;
        },
        function () {

        }
    );
}