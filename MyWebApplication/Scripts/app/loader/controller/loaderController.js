(function (module) {
    "use strict";
    //var myApp = angular.module('myApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache']);
//angular.module('MyApp', ['ngMaterial', 'material.svgAssetsCache'])

    module.controller('AppCtrl', ['$interval', '$scope',
        function ($interval, $scope) {
            $scope.activated = true;
            $scope.determinateValue = 30;

            $interval(function () {
                $scope.determinateValue += 3;
                if ($scope.determinateValue > 100) {
                    $scope.determinateValue = 0;
                }
            }, 100)
        }

    ]);

})(appMoules.loader)