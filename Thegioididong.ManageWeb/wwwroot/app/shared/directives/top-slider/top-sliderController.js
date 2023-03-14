// Register controller
var app = angular.module("DAGStore.common");
app.controller("topSliderController", topSliderController);

// Controller
function topSliderController($scope, apiService) {
    // Get Slider
    $scope.sliders = [];
    apiService.get("/index/showslider", null, function (result) {
        $scope.sliders = result.data;
        console.log($scope.sliders)
        var swiper = new Swiper(".mySwiper", {
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });
    }, function (error) {
        console.log("Get data fail");
    })
};