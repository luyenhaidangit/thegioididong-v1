

(function (app) {
    app.factory('sliderService', sliderService);

    // apiService.$inject = ['$http'];

    function sliderService() {
        return {
            createSliderProduct: createSliderProduct,
            createSliderEvent: createSliderEvent,
        }

        function createSliderEvent(config) {
            angular.element(document).ready(function () {
                var swiperEvent = new Swiper(config.selector, {
                    slidesPerView: 1,
                    spaceBetween: 0,
                    slidesPerGroup: 1,
                    loop: true,
                    loopFillGroupWithBlank: true,
                    autoplay: {
                        delay: 3000,
                        disableOnInteraction: false,
                    },
                    pagination: {
                        el: ".big-campaign__dot",
                        clickable: true,
                    },
                    navigation: {
                        nextEl: config.nextbutton,
                        prevEl: config.prebutton,
                    },

                    breakpoints: {
                        992: {
                            slidesPerView: 2,
                            spaceBetween: 16
                        }
                    }
                });
            });
        }

        function createSliderProduct(config) {
            angular.element(document).ready(function () {
                //Hot Deal Carousel
                var swiperHotDeal = new Swiper(config.selector, {
                    spaceBetween: 16,
                    slidesPerGroup: 2,
                    freeMode: true,
                    navigation: {
                        nextEl: config.nextbutton,
                        prevEl: config.prebutton,
                    },
                    breakpoints: {
                        1400: {
                            slidesPerView: 5,
                            spaceBetween: 16,
                            slidesPerGroup: 5,
                            loop: true,
                        },
                        1200: {
                            slidesPerView: 4,
                            spaceBetween: 24,
                            slidesPerGroup: 4,
                            loop: true,
                        },

                        992: {
                            slidesPerView: 3,
                            spaceBetween: 24,
                            slidesPerGroup: 3,
                            loop: true,
                        },
                        768: {
                            watchSlidesProgress: true,
                            slidesPerView: 2,
                            spaceBetween: 24,
                            slidesPerGroup: 2,
                        },
                        567: {
                            watchSlidesProgress: true,
                            slidesPerView: 2,
                            spaceBetween: 24,
                            slidesPerGroup: 2,
                            loop: true,
                            freeMode: false,
                        },
                    }
                });
            });
        }
    }
})(angular.module('DAGStore.common'));