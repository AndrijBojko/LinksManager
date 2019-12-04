var LnkControllers = angular.module("LnkControllers", []);  

LnkControllers.controller("ListController", ['$scope', '$http',  
    function($scope, $http) {
        $http.get('/api/links').then(function(response) {
            $scope.links = response.data;

            $scope.currentPage = 0;
            $scope.pageSize = 10;

            $scope.numberOfPages = function () {
                return Math.ceil($scope.links.length / $scope.pageSize);
            }
        },
        function(response)  
        {  
        	$scope.error = "An error has occured while getting data!"+response.data;
        });
    }  
]);  
 
LnkControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',  
    function($scope, $http, $routeParams, $location)  
    {  
        $scope.id = $routeParams.id;  
        $http.get('/api/links/' + $routeParams.id).then(function(response)  
        {  
        	$scope.category = response.data.Category;
        	$scope.url = response.data.Url;
        	$scope.description = response.data.Description;
        });  
        $scope.delete = function()  
        {  
            $http.delete('/api/links/' + $scope.id).then(function(response)  
            {  
                $location.path('/list');  
            },
            function (response)
            {  
                $scope.error = "An error has occured while deleting link! " + response.data;  
            });  
        };  
    }  
]);  

LnkControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',  
    function($scope, $filter, $http, $routeParams, $location)  
    {  
 
        $scope.id = 0;  

        $scope.save = function()  
        {  
            var obj = {  
                Id: $scope.id,  
                Category: $scope.category,
                Url: $scope.url,  
                Description: $scope.description  
            };  
            if ($scope.id === 0)  
            {  
                $http.post('/api/links/', obj).then(function(response)  
                {  
                    $location.path('/list');  
                },
                function (response)
                {  
                    $scope.error = "An error has occured while creating link! " + response.data.ExceptionMessage;  
                });  
            }  
            else  
            {  
                $http.put('/api/links/', obj).then(function(response)  
                {  
                    $location.path('/list');  
                },
                function (response)
                {  
                    console.log(response.data);  
                    $scope.error = "An Error has occured while editing link! " + response.data.ExceptionMessage;  
                });  
            }  
        }  
        if ($routeParams.id)  
        {  
            $scope.id = $routeParams.id;  
            $scope.title = "Edit Link";  
            $http.get('/api/links/' + $routeParams.id).then(function(response)  
            {  
                $scope.category = response.data.Category;  
                $scope.url = response.data.Url;   
                $scope.description = response.data.Description;  
            });  
        }  
        else  
        {  
            $scope.title = "Create New Link";  
        }  
    }  
]);



