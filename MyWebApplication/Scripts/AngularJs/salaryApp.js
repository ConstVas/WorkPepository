(function (window, angular, appModules) {
    "use strict";
    window.salaryApp = angular.module("salaryApp",
        ['ngAnimate',
            'ui.router',
             
            //appModules.loader.name//просто не может найти лоадер ??????7
             

    ]);
})(window, window.angular, window.appModules)