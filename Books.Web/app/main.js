var app = angular.module("BookEditorApp", ["ngMessages", "ngFileUpload"]);

app.constant("bookEditorSettings", { 
    apiBaseUri: "http://localhost:46457/api/"
});