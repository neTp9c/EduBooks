var app = angular.module("BookEditorApp", [
    "ngMessages",
    "ngFileUpload",
    "LocalStorageModule"
]);

app.constant("bookEditorSettings", { 
    apiBaseUri: "http://localhost:46457/api/"
});