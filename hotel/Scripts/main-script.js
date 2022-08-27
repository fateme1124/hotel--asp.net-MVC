function showPreview(input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            $('#impPrev').attr('src', e.target.result);
        }
        ImageDir.readAsDataURL(input.files[0]);
    }
}



//function changeLikeState(state, roomsId) {
//    $.ajax({
//        url: "/Roomses/ChangeLikeState",
//        type: "GET",
//        data: { roomsId: roomsId, state: state },
//        success: function (res) {
//            $("#showLike_" + roomsId).html(res);
//        },
//        error: function () {
//            alert("Error");
//        }

//    });
//}