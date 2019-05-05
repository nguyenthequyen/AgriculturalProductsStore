$(document).ready(function () {
    $('.btn-delete-address').click(managerAccount.openModalDeleteAddress);
});

var managerAccount = {
    openModalDeleteAddress: function () {
        $(commonFun.isWorking(this));
        var addressId = $('.isWorking').attr('address-id');
        $('.sumbit-delete').attr('value', addressId);
    },
}