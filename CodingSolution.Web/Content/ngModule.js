angular.module('myApp', []).controller('myCtrl', function ($scope, $timeout, $http, $window) {




    var selectedData = [];
    $scope.Sectors = [];
    $scope.errorMessage = "";
    $scope.successMessage = "";
    $scope.Cname = "";
    $scope.CandName = "";
    $(function () {
        $('#jstree').jstree({
            "core": {
                "multiple": true,
                "check_callback": false,
                'themes': {
                    "responsive": true,
                    'variant': 'larg',
                    'stripes': false,
                    'dots': false
                }
            },
            "checkbox": {
                "keep_selected_style": false
            },
            "types": {
                "default": {
                    "icon": "fa fa-check icon-state-warning icon-lg"
                },
                "file": {
                    "icon": "fa fa-file icon-state-warning icon-lg"
                }
            },
            "plugins": ["dnd", "state", "types", "sort", "checkbox"]
        }).on('changed.jstree', function (e, data) {
            selectedData = data.selected;

        });
    });



    $scope.ClearAllMessages = function () {
      
        $scope.errorMessage = "";
        $scope.successMessage = "";
    }

    $scope.ShowMessage = function (msg, type) {
        $scope.ClearAllMessages();
        if (type === 1) {
          
            $scope.errorMessage = msg;
        } else if (type === 2) {
          
            $scope.successMessage = msg;
        }

        $timeout(function () {
            $scope.ClearAllMessages();
        }, 3000);
    }


    $scope.ValidateForm = function () {
        var isValid = true;
        if ($scope.Cname === "") {
            isValid = false;
            $scope.ShowMessage("Name is mandatory field!", 1);
        } else
            if (selectedData.length ===0) {

                isValid = false;
                $scope.ShowMessage("Pick the Sectors you are currently involved in!", 1);
            } else
                if (!$scope.checkagree) {

                    isValid = false;
                    $scope.ShowMessage("You must to agree with terms!", 1);
                }
        return isValid;
    }


   

    $scope.SubimtForm = function () {
        if ($scope.ValidateForm()) {
            var dataObject = JSON.stringify(
                {
                    RegisterForm:
                        {
                            'Sector': selectedData,
                            'Name': $scope.Cname,
                            'Agree': $scope.checkagree
                        }
                });


            $http.post("/Home/RegisterForm", dataObject).then(function (response) {

                if (response.data.StatusCode === 0)
                {
                    $scope.CandName = response.data.Name;
                    $scope.Sectors = response.data.Sectors;
                    $scope.ShowMessage(response.data.Message, 2);
                }
                else
                {
                    $scope.ShowMessage(response.data.Message, 1);
                }

                
                
            }, function (error) {

            });
           
        }

    }

    $scope.InitUserSectors = function () {
    

        $http.get("/Home/GetUsersSectorsList").then(function (response) {

                if (response.data.StatusCode === 0) {
                    $scope.CandName = response.data.Name;
                    $scope.Sectors = response.data.Sectors;
                    $scope.Cname = response.data.Name;
                    $scope.checkagree = true;
                }
              
            }, function (error) {

            });

        

    }

    $scope.Delete = function (CandId,SectorId) {

        if (confirm("Are you sure you want to delete this Sector?")) {
            var dataObject = JSON.stringify(
                {
                    Applicants: {
                        CandidateId: CandId,
                        SectorId: SectorId
                    }
                   

                });

            $http.post("/Home/Delete", dataObject).then(function (response) {
                $scope.Sectors = response.data.Sectors;
                console.log($scope.Sectors);
            }, function (error) {

            });
        }
      

        

    }


});