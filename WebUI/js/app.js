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
        .state('form.myusergrid', {
            url: '/myusergrid',
            templateUrl: '../tpl/myusergrid.html',
            controller: 'mygridCtrl'
        })
        .state('login',{
            url:'/login',
            templateUrl:'../tpl/login.html',
            controller:'loginCtrl'
        });
    $urlRouterProvider.otherwise('/login');
});


myapp.controller('gridCtrl', function ($scope, $http, $state) {

    IsCheckLogin($http,$state, function () {

        var ID = $.cookie("ID");
        console.log(ID);
        //if (ID == undefined)
        //{
        //    $state.go('form.login');
        //}
        $("#backBut").hide();
        $scope.if = "0";
        //$http.get("../userinfo/GetUserInfos")
        //    .success(function (response) {
        //        console.log(response);
        //        //  console.log(response);
        //        $scope.NAMES = response;
        //        // var data = response;
        //        //for (i = 0; i < data.length; i++){
        //        //    $scope.NAMES[i].if = "1";
        //        //    //$scope.NAMES[i].DATA = ages(data[i].DATA);
        //        //}
        //    });
        var pageSize = 10;
        var pageindex = 1;
        var key;
        $scope.GetData = function (key) {
            pageindex = 1;
            key = key;
            $http({
                method: 'POST',
                url: "../userinfo/GetAll",
                data: {
                    "PAGE_SIZE": pageSize,
                    "PAGE_INDEX": pageindex,
                    "KEY": key == undefined ? "" : key,
                }
            }).success(function (res) {
                console.log(res);
                $scope.showloadingStyle = "display:none";
                $scope.noShowloadingStyle = "display:inline";
                $scope.NAMES = res;
            });
        }


        $scope.href = function (ev) {
            var uid = ev.x.UID;
            $state.go('form.detail', { uid: uid });
        }
        $scope.sexFilter = function (num) {
            if (num == 1) {
                $scope.sex = "男";
            } else if (num == 2) {
                $scope.sex = "女";
            }
            else {
                $scope.sex = "";
            }

            $scope.GetData($scope.sex);

           // $http.get("../userinfo/GetFilter?sex=" + $scope.sex)
           //.success(function (response) {
           //    console.log(response);
           //    $scope.NAMES = response;
           //});

        }

        $scope.showloadingStyle = "display:inline";
        $scope.noShowloadingStyle = "display:none";

        $scope.ContextText = "加载更多纪录";

        $scope.loadMore = function () {

            $scope.showloadingStyle = "display:inline";
            $scope.noShowloadingStyle = "display:none";

            pageindex = pageindex + 1;
            $http({
                method: 'POST',
                url: "../userinfo/GetAll",
                data: {
                    "PAGE_SIZE": pageSize,
                    "PAGE_INDEX": pageindex,
                    "KEY": key == undefined ? "" : key,
                }
            }).success(function (res) {
                var data = res;
                if (data != undefined && data.length != 0) {
                  
                }
                else {
                    pageindex -= 1
                    $scope.ContextText = "已经没有数据了";
                }

                $scope.showloadingStyle = "display:none";
                $scope.noShowloadingStyle = "display:inline";
                $scope.NAMES = $scope.NAMES.concat(res);
            });
        }


        $scope.GetData();
        //$scope.max = "88";
        //$scope.min = "18";
        //$scope.ageFilter = function() {
        //    var max = $scope.max;
        //    var min = $scope.min;
        //    var names = $scope.NAMES;
        //    for (i = 0; i < names.length; i++) {
        //        var age = names[i].DATA;
        //        if(age<min || age>max){
        //            names[i].if = "";
        //        }
        //    }
        //}
    });
});


myapp.controller('mygridCtrl', function ($scope, $http, $state) {


    IsCheckLogin($http,$state, function () {
        var ID = $.cookie("ID");
        console.log(ID);
        //if (ID == undefined) {
        //    $state.go('form.login');
        //}
        $("#backBut").hide();
        $scope.if = "0";
        $http.get("../userinfo/GetMyUserInfos")
            .success(function (response) {
                console.log(response);
                //  console.log(response);
                $scope.NAMES = response;
                // var data = response;
                for (i = 0; i < response.length; i++) {
                    $scope.NAMES[i].if = "1";

                    if( $scope.NAMES[i].UserType==0)
                    {
                        $scope.NAMES[i].UserType = "正在审核";
                    }
                    else if ($scope.NAMES[i].UserType == 1)
                    {
                        $scope.NAMES[i].UserType = "审核通过";
                    }
                    else if ($scope.NAMES[i].UserType == -1) {
                        $scope.NAMES[i].UserType = "审核未通过";
                    }
                }
            });

        $scope.href = function (ev) {
            var uid = ev.x.UID;
            $state.go('form.detail', { uid: uid });
        }
        //$scope.sexFilter = function (num) {
        //    if (num == 1) {
        //        $scope.sex = "男";
        //    } else if (num == 2) {
        //        $scope.sex = "女";
        //    }
        //    else {
        //        $scope.sex = "";
        //    }
        //    $http.get("../userinfo/GetMyFilter?sex=" + $scope.sex)
        //   .success(function (response) {
        //       console.log(response);
        //       $scope.NAMES = response;
        //   });

        //}
        //$scope.max = "88";
        //$scope.min = "18";
        //$scope.ageFilter = function() {
        //    var max = $scope.max;
        //    var min = $scope.min;
        //    var names = $scope.NAMES;
        //    for (i = 0; i < names.length; i++) {
        //        var age = names[i].DATA;
        //        if(age<min || age>max){
        //            names[i].if = "";
        //        }
        //    }
        //}

    });

 

});

myapp.controller('formSubmit', ['$scope', '$http', '$state', "Upload", function ($scope, $http, $state, Upload) {

    IsCheckLogin($http,$state, function () {
      
        $scope.form = {};

        $scope.form.SEX = '男';
        var ID = $.cookie("ID");
        console.log(ID);
        //if (ID == undefined) {
        //    $state.go('form.login');
        //}
        $scope.haspic = false;
        $scope.myImage = '/img/addPhoto1.jpg';
        var handleFileSelect = function (evt) {
            var file = evt.currentTarget.files[0];
            var reader = new FileReader();
            reader.onload = function (evt) {
                $scope.$apply(function ($scope) {
                    console.log(11);
                    $scope.haspic = true;
                    $scope.myImage = evt.target.result;
                  

                });
            };
            reader.readAsDataURL(file);
        };
        angular.element(document.querySelector('#fileInput')).on('change', handleFileSelect);
        $scope.processForm = function () {
            
            if ($scope.haspic) {
                $scope.form.ImageData = $scope.myImage;
            }
            else {
                alert("请上传图片！");
                return;
            }

            $http.post('/UserInfo/Create?r=' + Math.random(), $scope.form).success(function (res) {
                console.log(res);
                if (res=="OK") {
                    // $.cookie("ID", res.data.ID);
                    $state.go('form.usergrid');
                }
                else {
                    alert("添加失败！");
                }
            });
        };


        //$scope.upload = function (file) {
        //    $scope.fileInfo = file;
        //    Upload.upload({
        //        //服务端接收
        //        url: '/UserInfo/ProcessRequest',
        //        //上传的同时带的参数
        //        data: { 'username': $scope.username },
        //        file: file
        //    }).progress(function (evt) {
        //        //进度条
        //        console.log(evt)
        //        var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
        //        console.log('progess:' + progressPercentage + '%' + evt.config.file.name);
        //    }).success(function (data, status, headers, config) {
        //        //上传成功
        //        console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
        //    }).error(function (data, status, headers, config) {
        //        //上传失败
        //        console.log('error status: ' + status);
        //    });
        //};

        //$scope.submitimg = function () {
        //    $scope.upload($scope.file);
        //};

       

    });

}]);

myapp.controller('detailCtrl', function ($scope, $state, $stateParams, $http) {
    IsCheckLogin($http,$state, function () {
        $("#backBut").show();
        var uid = $stateParams.uid;
        var ID = $.cookie("ID");
        console.log(ID);
        $http.get("../userinfo/GetEntity?uid=" + uid)
            .success(function (response) {
                $scope.detail = response;
                var detail = response;
                $scope.da = detail.DATA;
                $scope.pl = detail.PLACE;
                $scope.na = detail.NATION;
                $scope.he = detail.HEIGHT;
                $scope.ed = detail.EDUCATION;
                $scope.school = detail.SCHOOL;
                $scope.his = detail.HISTORY;
                $scope.workt = detail.WORKT;
                $scope.phone = detail.PHONE;
                $scope.add = detail.ADDRESS;
                $scope.ins = detail.INTEREST;
                $scope.wp = detail.WORKPLACE;
                $scope.oh = detail.OHEIGHT;
                $scope.ow = detail.OWORK;
                $scope.oi = detail.OINTEREST;
                $scope.os = detail.OSTRENGTH;
                $scope.max = detail.MAX;
                $scope.min = detail.MIN;
                $scope.w = detail.OWORKPLACE;
                $scope.f = detail.FAMILY;

            });

    })

  
});


function IsCheckLogin($http,$state,callBack)
{
    $http.get('Gate/IsUserLogin').success(function (res) {
        console.log(res);
        if (res.success) {
            callBack();
        }
        else {
            $state.go('login');
        }
    });
}

myapp.controller('loginCtrl', function ($scope, $state, $http) {
   $scope.loginData = {};
    $scope.login = function(){

        //$scope.loginData.name = "admin";
        //$scope.loginData.password = "admin1";

        $http.post('Gate/CheckUser?r='+Math.random(), {
            name: $scope.loginData.username,
            password: $scope.loginData.password
        }).success(function (res) {
            console.log(res);
            if (res.success) {
                $.cookie("ID", res.data.ID);
                $state.go('form.usergrid');
            }
            else {
                alert("账户或密码错误！");
            }
        
        });
    }
});