angular.module("AsyncTemplates").directive('rvContentItem', function ($http, $templateCache, $compile, $parse, $timeout) {
    return {
        restrict: 'AE',
        scope: {
            contentItemId: '@',
            displayType: '@',
            resourceUrl: '@',
            contentItem: '='
        },
        template: '<div ng-include="model.templates.angular"></div>',
        link: function (scope, iElement, iAttrs) {

            var itemIdTimeout;

            function updateContent(resourceUrl) {

                    $http.get(resourceUrl).then(function (response) {
                        scope.model = response.data;
                    });

            }

            function buildResourceUrl(contentItemId,displayType) {
                
                if (!contentItemId || !displayType) {
                    return;
                }

                if (itemIdTimeout) $timeout.cancel(itemIdTimeout);

                var resourceUrl = '/api/morphous.api/item/' + contentItemId;
                if (displayType !== "Detail") {
                    resourceUrl +=  '/' + displayTypel
                }

                itemIdTimeout = $timeout(function () { updateContent(resourceUrl) },150);
            }

            scope.navigate = function (resourceUrl) {
                scope.$emit('navigate', { resourceUrl: resourceUrl });
            };

            scope.$watch('contentItemId', function (newValue) {
                buildResourceUrl(newValue, scope.displayType);
            });

            scope.$watch('displayType', function (newValue) {
                buildResourceUrl(scope.contentItemId, newValue);
            });

            scope.$watch('resourceUrl', function (newValue) {
                if (!newValue)
                    return;

                updateContent(newValue);
            });

            
            scope.$watch('contentItem', function (newValue) {
                scope.model = newValue;
            });
          
        }
    }
});