$(document).ready(function () {

});

var commonFun = {
    isWorking: function (result) {
        var find = $('.container .btn-delete-address').find('.isWorking');
        if (find) {
            $('.container .btn-delete-address').removeClass('isWorking');
        }
        $(result).addClass('isWorking');
    },
}