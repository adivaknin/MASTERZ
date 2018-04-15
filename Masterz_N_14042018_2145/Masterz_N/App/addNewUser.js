angular.module('app.addNewUser', [])

    .controller('AddNewUserController', function ($scope, $http) {
        $scope.options = [{ name: "050", id: 1 }, { name: "052", id: 2 }];
    });