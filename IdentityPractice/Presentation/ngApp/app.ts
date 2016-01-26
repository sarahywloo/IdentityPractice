namespace IdentityPractice {
    angular.module("IdentityPractice", ['ngRoute', 'ui.bootstrap'])
        .config(function ($routeProvider: ng.route.IRouteProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: '/Presentation/ngApp/views/newsFeed.html',
                    controller: IdentityPractice.Controllers.NewsFeedController,
                    controllerAs: 'controller'
                });
        });
}