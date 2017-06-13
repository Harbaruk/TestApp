(function ($scope, $http) {
    'use strict';

    var app = angular
        .module('app');


    // Define the `PhoneListController` controller on the `phonecatApp` module
    app.controller('phoneController', function PhoneListController($scope, $http) {
        $http({
            method: 'GET',
            url: 'http://localhost:57608/phones/all/0'
        }).then(function successCallback(response) {
            $scope.phones = response.data.phones;
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });

        $scope.add = function () {

            $http({
                method: 'POST',
                url: 'http://localhost:57608/phones/add',
                data: { model: "IPhone 5S", company: "IPhone", price: 18.5, description: null, category: 0 }
            }).then(function successCallback(response) {
                alert('ok')
            }, function errorCallback(response) {
                alert('bad')
            });
        }
    });


})();
