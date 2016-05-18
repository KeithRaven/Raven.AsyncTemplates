app.controller('ItemController', ['$scope', function ($scope) {
    $scope.contentItemId = null;
    $scope.displayType = null;
    $scope.resourceUrl = null;

    $scope.$on('navigate', function (event, args) {
        $scope.resourceUrl = args.resourceUrl;
    });

    $scope.navigateContent = function (resourceUrl) {
        $scope.resourceUrl = resourceUrl;
    }
}]);