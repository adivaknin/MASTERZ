/// <reference path="../View/Users.html" />
'use strict';

// Declares how the application should be bootstrapped. See: http://docs.angularjs.org/guide/module
angular.module('app',
    [
        // Dependency Inject Goes inside this array
        'ui.router',  // we inject/load ui-router for routing
        'app.controllers', // we inject/load the controllers
        'app.users','app.editExistUser','app.addNewUser','app.events','app.editExistEvent','app.graficScreen',
        'app.statisticScreen','app.screenTargets','app.addNewEvent','app.login','app.luhotZmanim',
        'app.graficScreen','app.securityLogin','app.halalimLeHaskara','app.messages',
        'app.lessonSchedule','app.checkOutfit','app.addNewLesson',
        'app.editLesson','app.systemPanel','app.updateExistingService',
    ]
)
    .config(['$stateProvider',
        function ($stateProvider) {
            // UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router

            // our routers, self explanatory
            $stateProvider
                .state('home', {
                    url: '/home',
                    templateUrl: './View/Home.html',
                    controller: 'HomeController'
                })
                .state('login', {
                    url: '/login',
                    templateUrl: './View/Login.html',
                    controller: 'LoginController'
                })
                .state('users', {
                    url: '/users',
                    templateUrl: './View/Users.html',
                    controller: 'UsersController'
                })
                .state('editExistUser', {
                    url: '/editExistUser',
                    templateUrl: './View/EditExistUser.html',
                    controller: 'EditExistUserController'
                })
                .state('addNewUser', {
                    url: '/addNewUser',
                    templateUrl: './View/AddNewUser.html',
                    controller: 'AddNewUserController'
                })
                .state('luhotZmanim', {
                    url: '/luhotZmanim',
                    templateUrl: './View/LuhotZmanim.html',
                    controller: 'LuhotZmanimController'
                })
                .state('events', {
                    url: '/events',
                    templateUrl: './View/Events.html',
                    controller: 'EventsController'
                })
                .state('addNewEvent', {
                    url: '/addNewEvent',
                    templateUrl: './View/AddNewEvent.html',
                    controller: 'AddNewEventController'
                })
                .state('editExistEvent', {
                    url: '/editExistEvent',
                    templateUrl: './View/EditExistEvent.html',
                    controller: 'EditExistEventController'
                })
                .state('movies', {
                    url: '/movies',
                    templateUrl: './View/Movies.html',
                    controller: 'MasterzController'
                })
                .state('graficScreen', {
                    url: '/graficScreen',
                    templateUrl: '/View/GraficScreen.html',
                    controller: 'GraficScreenController'
                })
                .state('statisticScreen', {
                    url: '/statisticScreen',
                    templateUrl: '/View/StatisticScreen.html',
                    controller: 'StatisticScreenController'
                })
                .state('screenTargets', {
                    url: '/screenTargets',
                    templateUrl: '/View/ScreenTargets.html',
                    controller: 'ScreenTargetsController'
                })
                .state('securityLogin', {
                    url: '/securityLogin',
                    templateUrl: '/View/SecurityLogin.html',
                    controller: 'SecurityLoginController'
                })
                .state('halalimLeHaskara', {
                    url: '/halalimLeHaskara',
                    templateUrl: '/View/HalalimLeHaskara.html',
                    controller: 'HalalimLeHaskaraController'
                })
                .state('messages', {
                    url: '/messages',
                    templateUrl: '/View/Messages.html',
                    controller: 'MessagesController'
                })
                .state('lessonSchedule', {
                    url: '/lessonSchedule',
                    templateUrl: '/View/LessonSchedule.html',
                    controller: 'LessonScheduleController'
                })
                .state('checkOutfit', {
                    url: '/checkOutfit',
                    templateUrl: '/View/CheckOutfit.html',
                    controller: 'CheckOutfitController'
                })
                .state('addNewLesson', {
                    url: '/addNewLesson',
                    templateUrl: '/View/AddNewLesson.html',
                    controller: 'AddNewLessonController'
                })
                .state('editLesson', {
                    url: '/editLesson',
                    templateUrl: '/View/EditLesson.html',
                    controller: 'EditLessonController'
                })
                .state('systemPanel', {
                    url: '/systemPanel',
                    templateUrl: '/View/SystemPanel.html',
                    controller: 'SystemPanelController'
                })
                .state('updateExistingService', {
                    url: '/updateExistingService',
                    templateUrl: '/View/UpdateExistingService.html',
                    controller: 'UpdateExistingServiceController'
                })
                .state('eventSide', {
                    url: '/eventSide',
                    templateUrl: '/Controllers/EventSide.html',
                    controller: 'MasterzController'
                })
                .state('userSide', {
                    url: '/userSide',
                    templateUrl: '/Controllers/UserSide.html',
                    controller: 'MasterzController'
                })
                .state('screenSide', {
                    url: '/screenSide',
                    templateUrl: '/Controllers/ScreenSide.html',
                    controller: 'MasterzController'
                })
                .state('otherwise', {
                    url: '*path',
                    templateUrl: '/View/Error.html',
                    controller: 'ErrorCtrl'
                });
        
        }]

        );
