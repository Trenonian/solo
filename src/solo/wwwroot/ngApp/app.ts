namespace solo {

    angular.module('solo', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/home.html',
                controller: solo.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/login.html',
                controller: solo.Controllers.LogInController,
                controllerAs: 'controller'
            })
            .state('allboards', {
                url: '/b/',
                templateUrl: '/ngApp/allboards.html',
                controller: solo.Controllers.AllBoardsController,
                controllerAs: 'controller'
            })
            .state('board', {
                url: '/b/:board',
                templateUrl: '/ngApp/board.html',
                controller: solo.Controllers.BoardController,
                controllerAs: 'controller'
            })
            .state('post', {
                url: '/b/:board/:post',
                templateUrl: '/ngApp/post.html',
                controller: solo.Controllers.PostController,
                controllerAs: 'controller'
            })
            .state('user', {
                url: '/u/:user',
                templateUrl: '/ngApp/user.html',
                controller: solo.Controllers.UserController,
                controllerAs: 'controller'
            })
            .state('testhome', {
                url: '/testhome',
                templateUrl: '/ngApp/testhome.html',
                controller: solo.Controllers.TestHomeController,
                controllerAs: 'controller'
            })
            .state('testboard', {
                url: '/testboard',
                templateUrl: '/ngApp/testboard.html',
                controller: solo.Controllers.TestBoardController,
                controllerAs: 'controller'
            })
            .state('testpost', {
                url: '/testpost',
                templateUrl: '/ngApp/testpost.html',
                controller: solo.Controllers.TestPostController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

}
