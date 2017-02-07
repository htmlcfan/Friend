var virtualUrl = "";


var myapp = angular.module('myApp',['ngAnimate','ui.router','ngFileUpload']);
myapp.config(function($stateProvider,$urlRouterProvider){
    $stateProvider
        .state('form',{
            url:'/form',
            templateUrl:'../tpl/form.html'
        })
        .state('form.detail',{
            url:'/detail/:uid',
            templateUrl:'../tpl/detail.html',
            controller:'detailCtrl'
        })
        .state('form.user',{
            url:'/user',
            templateUrl:'../tpl/user.html',
            controller:'formSubmit'
        })
        .state('form.usergrid',{
            url:'/usergrid',
            templateUrl:'../tpl/usergrid.html',
            controller:'gridCtrl'
        })
        .state('login',{
            url:'/login',
            templateUrl:'../tpl/login.html',
            controller:'loginCtrl'
        });
    $urlRouterProvider.otherwise('/login');
});


myapp.controller('gridCtrl',function($scope,$http,$state){
    $("#backBut").hide();
    $scope.if = "0";
    $http.get("../data/Films.json")
        .success(function (response) {
            $scope.NAMES = response.data;
            var data = response.data;
            for (i = 0; i < data.length; i++){
                $scope.NAMES[i].if = "1";
                $scope.NAMES[i].DATA = ages(data[i].DATA);
            }
        });

    $scope.href = function(ev){
      var uid = ev.x.UID;
        $state.go('form.detail',{uid:uid});
    }
    $scope.sexFilter = function(num){
        if(num == 1){
            $scope.sex = "男";
        }else{
            $scope.sex = "女";
        }
    }
    $scope.max = "88";
    $scope.min = "18";
    $scope.ageFilter = function() {
        var max = $scope.max;
        var min = $scope.min;
        var names = $scope.NAMES;
        for (i = 0; i < names.length; i++) {
            var age = names[i].DATA;
            if(age<min || age>max){
                names[i].if = "";
            }
        }
    }

});
myapp.controller('formSubmit', ['$scope', function($scope) {
    $scope.myImage='';
    var handleFileSelect=function(evt) {
        var file=evt.currentTarget.files[0];
        var reader = new FileReader();
        reader.onload = function (evt) {
            $scope.$apply(function($scope){
                $scope.myImage=evt.target.result;

            });
        };
        reader.readAsDataURL(file);
    };
    angular.element(document.querySelector('#fileInput')).on('change',handleFileSelect);
    $scope.form = {};
    $scope.processForm = function(){
        console.log($scope.form);
    }
}]);

myapp.controller('detailCtrl',function($scope, $state, $stateParams,$http){
    $("#backBut").show();
    var uid = $stateParams.uid;
    $http.get("../data/Films.json")
        .success(function (response) {
            var detail = response.data;
            for (i = 0; i < detail.length; i++) {
                if (detail[i].UID == uid) {
                    $scope.detail = detail[i];
                    $scope.ins = detail[i].INTEREST;
                    $scope.oh = detail[i].OHEIGHT;
                    $scope.ow = detail[i].OWORK;
                    $scope.oi = detail[i].OINTEREST;
                    $scope.os = detail[i].OSTRENGTH;
                    $scope.max = detail[i].MAX;
                    $scope.min = detail[i].MIN;
                    $scope.w = detail[i].OWORKPLACE;
                    $scope.f = detail[i].FAMILY;
                    break;
                }
            }

        });

});

myapp.controller('loginCtrl',function($scope,$state){
   $scope.loginData = {};
    $scope.login = function(){
        $state.go('form.usergrid');
    }

});