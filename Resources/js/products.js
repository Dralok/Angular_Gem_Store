

//(function () {
  
    var kb = kb || {};
    kb.resourcePath = document.location.href.substring(0, document.location.href.lastIndexOf('/')) + '/DesktopModules/Angular_Gem_Store/Resources/';

    kb.storeProducts = angular.module('store-products', []);

    kb.storeProducts.directive('productGallery', function () {
        return {
            restrict: 'E',
            templateUrl: kb.resourcePath + 'templates/product-gallery.html',
            controller: function () {
                this.path = kb.resourcePath;
                this.current = 0;
                this.setCurrent = function (setCur) {
                    this.current = setCur || 0;
                };
            },
            controllerAs: 'gal'
        }
    });
    kb.storeProducts.directive('productTitle', function () {
        return {
            restrict: 'E',
            templateUrl: kb.resourcePath + 'templates/product-title.html'
        };
    });
    kb.storeProducts.directive('productSpecs', function () {
        return {
            restrict: 'E',
            templateUrl: kb.resourcePath + 'templates/product-specs.html'
        };
    });
    kb.storeProducts.directive('productDescription', function () {
        return {
            restrict: 'E',
            templateUrl: kb.resourcePath + 'templates/product-description.html'
        };
    });
    kb.storeProducts.directive('productReviews', function () {
        return {
            restrict: 'E',
            templateUrl: kb.resourcePath + 'templates/product-reviews.html'//,
        }
    });
    kb.storeProducts.directive('productChartBar', function () {
        return {
            restrict: 'AE',
            templateUrl: kb.resourcePath + 'templates/product-chart-bar.html',
            controller: function ($scope, $window, $log, dnnServiceClient, global) {
                $scope.objData = global.getObjectData();
            }
        }
    });
    kb.storeProducts.directive('productChartPolar', function () {
        return {
            restrict: 'AE',
            templateUrl: kb.resourcePath + 'templates/product-chart-polar.html',
            controller: function ($scope, $window, $log, dnnServiceClient, global) {
                $scope.objData = global.getObjectData();

            }
        }
    });
    kb.storeProducts.directive('productChartLine', function () {
        return {
            restrict: 'AE',
            templateUrl: kb.resourcePath + 'templates/product-chart-line.html',
            controller: function ($scope, $window, $log, dnnServiceClient, global) {
                $scope.objData = global.getObjectData();
            }
           
        }
    });
    kb.storeProducts.directive('productPanels', function () {
        return {
            restrict: 'E',
            templateUrl: kb.resourcePath + 'templates/product-panels.html',
            controller: function () {
                this.tab = 1;

                this.selectTab = function (setTab) {
                    this.tab = setTab;
                };
                this.isSelected = function (checkTab) {
                    return this.tab === checkTab;
                };
            },
            controllerAs: 'panel'
        };
    });

//});