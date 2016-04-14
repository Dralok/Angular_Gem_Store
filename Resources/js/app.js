

//(function () {
var kb = kb || {};
kb.resourcePath = document.location.href.substring(0, document.location.href.lastIndexOf('/')) + '/DesktopModules/Angular_Gem_Store/Resources/';


    kb.gemStore = angular.module('gemStore', ['chart.js', 'store-products']);

    kb.gemStore.controller('StoreController', function ($scope, $window, $log, $interval, dnnServiceClient, global) {
        $scope = this;
        $scope.firstLoad = true;
        $scope.Products = []; // gems;
        $scope.Title = 'Startup';
        
        $scope.init = function (moduleId, moduleName) {
           // $window.dispatchEvent(new Event('resize'));
            $scope.ModuleId = moduleId;
            dnnServiceClient.init(moduleId, moduleName);
            $scope.getTitle();

                       $scope.getInventory();
                        
        };

        $scope.getTitle = function () {
            dnnServiceClient.callGetService("item/test")
                            .then(function (payload) {
                                $scope.Title = payload.data.Message;
                            },
                            function (errorPayload) {
                                $log.error('failure loading title', errorPayload);
                            });
        };
        
        $scope.getInventory = function () {

            dnnServiceClient.callGetService("item/items")
                            .then(function (payload) {
                                $scope.Products = payload.data;
                                global.setChartDataBuild($scope.Products, 'Name', '', 'Price');
                                //if ($scope.firstLoad) $window.dispatchEvent(new Event('resize'));
                                //$scope.firstLoad = false;
                            },
                            function (errorPayload) {
                                $log.error('failure loading items', errorPayload);
                            });
        };

        //$interval(function() {
        //    $scope.getInventory();
        //}, 1000)

        $scope.saveItem = function (item) {
            dnnServiceClient.callPostService("item/save", item)
                            .then(function (payload) {
                                item = payload.data;
                            },
                            function (errorPayload) {
                                $log.error('failure loading title', errorPayload);
                            });
        };

        //$scope.getChartData = function () {
        //    $scope.chartData.labels = $scope.Products.map(function (data) {
        //        return data.Name;
        //    });
        //    $scope.chartData.data = [$scope.Products.map(function (data) {
        //        return data.Price;
        //    })];
        //};
    });

    kb.gemStore.controller('ReviewController', function ($scope, $window, $log, dnnServiceClient) {
        this.review = {};

        this.addReview = function (store, product) {
            this.review.ItemId = product.RecordId;
            //product.Reviews.push(this.review);
            $scope.saveReview(store, this.review);
            this.review = {};
        };

        $scope.saveReview = function (store, review) {
            dnnServiceClient.callPostService("item/savereview", review)
                            .then(function (payload) {
                                for (i = 0; i < store.Products.length; i++) {
                                    if (payload.data.RecordId === store.Products[i].RecordId)
                                        store.Products[i] = payload.data;
                                }
                                   
                            },
                            function (errorPayload) {
                                $log.error('failure saving review', errorPayload);
                            });
        };

    });

    //kb.gemStore.controller('ctrlChart', function ($scope, $window, $log, dnnServiceClient, global) {
    //    $scope.objData = global.getObjectData();
    //});

    kb.gemStore.factory("dnnServiceClient", ['$http', function ($http) {
        $self = this;

        return {
            init: function (moduleId, moduleName) {
                if ($.ServicesFramework) {
                    var _sf = $.ServicesFramework(moduleId);
                    $self.ServiceRoot = _sf.getServiceRoot(moduleName);
                    $self.Headers = {
                        "ModuleId": moduleId,
                        "TabId": _sf.getTabId(),
                        "RequestVerificationToken": _sf.getAntiForgeryValue()
                    };
                }
            },
            callGetService: function (method) {
                return $http({
                    method: 'GET',
                    url: $self.ServiceRoot + method,
                    headers: $self.Headers
                });
            },
            callPostService: function (method, data) {
                return $http({
                    method: 'POST',
                    url: $self.ServiceRoot + method,
                    headers: $self.Headers,
                    data: data
                });
            }
        }
    }]);
  
    kb.gemStore.service('global', function () {
        var objData = {
            chartData: {
                labels: [],
                series: [],
                data: [[]],
                options: { }
            }
        };

        return {
            getObjectData: function () {
                return objData;
            },
            setObjectData: function(object){
                objData = object;
            },
            setChartDataBuild: function (object, labelsProp, seriesProp, dataProp) {
                var chartData = {};
                chartData.labels = object.map(function (data) { return data[labelsProp]; });
                chartData.series = seriesProp.length > 0 ? object.map(function (data) { return data[seriesProp]; }) : [];
                if (chartData.series.length === 0) {
                    chartData.data = [object.map(function (data) { return data[dataProp]; })];
                } else {
                    chartData = []
                    for (sIndex = 0; sIndex < chartData.series.length; sIndex++) {
                        var lcData = [];
                        for (oIndex = 0; oIndex < object.length; oIndex++) {
                            if (object[oIndex][seriesProp] === chartData.series[sIndex]) {
                                lcData.push(object[oIndex][dataProp]);
                            }
                        }
                        chartData.push(lcData);
                    }
                }
               
                objData.chartData = chartData;
            }
        };
    });



    var gems = [{
        name: 'Azurite',
        description: "Some gems have hidden qualities beyond their luster, beyond their shine... Azurite is one of those gems.",
        shine: 8,
        price: 110.50,
        rarity: 7,
        color: '#CCC',
        faces: 14,
        images: [
          "images/gem-02.gif",
          "images/gem-05.gif",
          "images/gem-09.gif"
        ],
        reviews: [{
            stars: 5,
            body: "I love this gem!",
            author: "joe@example.org",
            createdOn: 1397490980837
        }, {
            stars: 1,
            body: "This gem sucks.",
            author: "tim@example.org",
            createdOn: 1397490980837
        }]
    }, {
        name: 'Bloodstone',
        description: "Origin of the Bloodstone is unknown, hence its low value. It has a very high shine and 12 sides, however.",
        shine: 9,
        price: 22.90,
        rarity: 6,
        color: '#EEE',
        faces: 12,
        images: [
          "images/gem-01.gif",
          "images/gem-03.gif",
          "images/gem-04.gif"
        ],
        reviews: [{
            stars: 3,
            body: "I think this gem was just OK, could honestly use more shine, IMO.",
            author: "JimmyDean@example.org",
            createdOn: 1397490980837
        }, {
            stars: 4,
            body: "Any gem with 12 faces is for me!",
            author: "gemsRock@example.org",
            createdOn: 1397490980837
        }]
    }, {
        name: 'Zircon',
        description: "Zircon is our most coveted and sought after gem. You will pay much to be the proud owner of this gorgeous and high shine gem.",
        shine: 70,
        price: 1100,
        rarity: 2,
        color: '#000',
        faces: 6,
        images: [
          "images/gem-06.gif",
          "images/gem-07.gif",
          "images/gem-10.gif"
        ],
        reviews: [{
            stars: 1,
            body: "This gem is WAY too expensive for its rarity value.",
            author: "turtleguyy@example.org",
            createdOn: 1397490980837
        }, {
            stars: 1,
            body: "BBW: High Shine != High Quality.",
            author: "LouisW407@example.org",
            createdOn: 1397490980837
        }, {
            stars: 1,
            body: "Don't waste your rubles!",
            author: "nat@example.org",
            createdOn: 1397490980837
        }]
    }];
//})();