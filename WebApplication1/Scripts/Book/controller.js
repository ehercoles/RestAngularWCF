/// <reference path="../angular.min.js" />  
/// <reference path="module.js" />  
/// <reference path="service.js" />  

app.controller("CRUD_AngularJs_RESTController", function ($scope, CRUD_AngularJs_RESTService) {

    $scope.OperType = 1;
    //1 Mean New Entry  

    GetAllRecords();
    //To Get All Records  
    function GetAllRecords() {
        var promiseGet = CRUD_AngularJs_RESTService.getBook();
        promiseGet.then(function (pl) { $scope.Books = pl.data },
            function (errorPl) {
                $log.error('Some Error in Getting Records.', errorPl);
            });
    }

    //To Clear all input controls.  
    function ClearModels() {
        $scope.OperType = 1;
        $scope.BookId = "";
        $scope.Name = "";
    }

    //To Create new record and Edit an existing Record.  
    $scope.save = function () {
        var Book = {
            Name: $scope.Name
        };
        if ($scope.OperType === 1) {
            var promisePost = CRUD_AngularJs_RESTService.post(Book);
            promisePost.then(function (pl) {
                $scope.BookId = pl.data.BookId;
                GetAllRecords();

                ClearModels();
            }, function (err) {
                console.log("Some error Occured" + err);
            });
        } else {
            //Edit the record      
            debugger;
            Book.BookId = $scope.BookId;
            var promisePut = CRUD_AngularJs_RESTService.put($scope.BookId, Book);
            promisePut.then(function (pl) {
                $scope.Message = "Book Updated Successfuly";
                GetAllRecords();
                ClearModels();
            }, function (err) {
                console.log("Some Error Occured." + err);
            });
        }
    };

    //To Get Book Detail on the Base of Book ID  
    $scope.get = function (Book) {
        var promiseGetSingle = CRUD_AngularJs_RESTService.get(Book.BookId);
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.BookId = res.BookId;
            $scope.Name = res.Name;
            $scope.OperType = 0;
        },
            function (errorPl) {
                console.log('Some Error in Getting Details', errorPl);
            });
    }

    //To Delete Record  
    $scope.delete = function (Book) {
        var promiseDelete = CRUD_AngularJs_RESTService.delete(Book.BookId);
        promiseDelete.then(function (pl) {
            $scope.Message = "Book Deleted Successfuly";
            GetAllRecords();
            ClearModels();
        }, function (err) {
            console.log("Some Error Occured." + err);
        });
    }
});
