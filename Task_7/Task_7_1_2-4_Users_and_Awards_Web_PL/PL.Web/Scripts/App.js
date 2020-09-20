const defaultAwardImage = "/Icons/medal.png";
const defaultUserImage = "/Icons/user.png";

$(document).ready(onReady);

function onReady() {
    $('.item').click(editObject)
    $('.deleteItem').click(removeObject)
    $('#modal_file').change(uploadAvatar)
    $('#modal_save').click(saveObject)
    $('.modal_list_plus').click(addNexus)
}

function editObject() {
    let type
    let id = this.id
    $('#modal_itemId').val(id)

    if ($(this).parent().parent().attr('id') == "usersList") {
        type = "user"
        $('#modal_award_sect').hide()
        $('#modal_user_sect').show()
        $('#modal_user_image').attr('src', defaultUserImage)
        $('#modal_title').html("User")

        if (id === "") {
            $('#birthDate').val("")
            $('#modal_age').val("")
            $('#modal_user_name').val("")
            $('#modal_birthday').val("")
        }
        else {
            $.getJSON('/Pages/getUserProfile.cshtml', { 'id': id }, function (data) {
                $('#modal_user_name').val(data['Name'])
                $('#modal_birthday').val(data['DateOfBirth'])
                $('#modal_age').val(data['Age'])
                if (data['Avatar'] != null) {
                    $('#modal_user_image').attr('src', data['Avatar'])
                }
            })
        }
    }
    else {
        type = "award"
        $('#modal_user_sect').hide()
        $('#modal_award_sect').show()
        $('#modal_award_image').attr('src', defaultAwardImage)
        $('#modal_title').html("Award")

        if (id == "") {
            $('#modal_award_title').val("")
        }
        else {
            $.getJSON('/Pages/getAwardProfile.cshtml', { 'id': id }, function (data) {
                $('#modal_award_title').val(data['Title'])
                if (data['Avatar'] != null) {
                    $('#modal_award_image').attr('src', data['Avatar'])
                }
            })
        }
    }

    $('#modal_itemType').val(type)
    getUserAwards(id, type)
    $("#itemEditModal").modal('show')
}

function saveObject() {
    let data = {}
    let name
    let ava
    let type = $('#modal_itemType').val()
    let id = $('#modal_itemId').val()

    if (type == "user") {
        let birthday = $('#modal_birthday').val()
        ava = $('#modal_user_image').attr('src')
        if (ava == defaultUserImage) {
            ava = null
        }
        name = $('#modal_user_name').val()
        data.DateOfBirth = birthday
        data.Image = ava
    }
    else {
        ava = $('#modal_award_image').attr('src')
        if (ava == defaultAwardImage) {
            ava = null;
        }
        name = $('#modal_award_title').val()
    }

    data.Type = type
    data.Id = id
    data.Name = name
    data.Avatar = ava

    $.post("/Pages/saveObject.cshtml",
        data,
        function (data) {
            if (data == "") {
                $("#itemEditModal").modal('hide');
                displayNotificationMessage("Saved!")
                type == 'user' ? updateInfo('user') : updateInfo('award')
            }
            else
                displayNotificationMessage(data)
        })
}

function removeObject() {
    event.stopPropagation()
    let id = $(this).parent().attr('id')
    $(this).parent().parent().parent().attr('id') == "usersList" ? type = "user" : type = "award"

    if (type == "user") {
        $('#confirm_body').html("Are you sure you want to delete the user?")
    } else {
        $('#confirm_body').html("Are you sure you want to delete the award?")
    }

    $('#confirm_delete_but').click(function () {
        $.post("/Pages/removeObject.cshtml",
            {
                Type: type,
                Id: id
            },
            function () {
                displayNotificationMessage("Removed!")
                $('#confirm_delete').modal('hide')
                type == 'user' ? updateInfo('user') : updateInfo('award')
            })
    })

    $('#confirm_delete').modal('show')
}

function uploadAvatar() {
    if (this.files && this.files[0]) {

        let imgParentDiv

        if ($('#modal_itemType').val() == 'user') {
            imgParentDiv = $('#modal_user_image').parent()
        } else {
            imgParentDiv = $('#modal_award_image').parent()
        }            

        let max_width = $(imgParentDiv)[0].offsetWidth
        let max_height = $(imgParentDiv)[0].offsetHeight
        let reader = new FileReader()

        reader.readAsDataURL(this.files[0])
        reader.onload = function (event) {
            let img = new Image()
            img.src = event.target.result
            img.onload = () => {
                let scaleFactor = img.height / img.width
                let new_width = max_width;
                let new_height = new_width * scaleFactor
                if (new_height > max_height) {
                    new_height = max_height;
                    new_width = new_height / scaleFactor
                }

                let elem = document.createElement('canvas')
                elem.width = new_width
                elem.height = new_height
                let ctx = elem.getContext('2d')

                ctx.drawImage(img, 0, 0, new_width, new_height)

                if ($('#modal_itemType').val() == 'user') {
                    $('#modal_user_image').attr('src', elem.toDataURL())
                } else {
                    $('#modal_award_image').attr('src', elem.toDataURL())
                }       
            }
        }
    }
}

function updateInfo(type) {
    if (type == 'user') {
        $.get("/Pages/listOfUsers.cshtml",
            null,
            function (data) {
                $('#users').html(data)
                $('.item').click(editObject)
                $('.deleteItem').click(removeObject)
            })
    }
    else {
        $.get("/Pages/listOfAwards.cshtml",
            null,
            function (data) {
                $('#awards').html(data)
                $('.item').click(editObject)
                $('.deleteItem').click(removeObject)
            })
    }
}

function addNexus() {
    let parentId = $('#modal_itemId').val()
    let type = $('#modal_itemType').val()

    $.post("/Pages/modalListSmall.cshtml",
        {
            Type: type,
            Id: parentId
        },
        function (data) {
            $('#modal_list_item_to_add_body').html(data)
            $('.item-to-pick').click(function () {
                let userId
                let awardId
                let childId = $(this).attr('id')
                if (type == "user") {
                    userId = parentId
                    awardId = childId
                }
                else {
                    userId = childId
                    awardId = parentId
                }
                $.post("/Pages/addNexus.cshtml",
                    {
                        UserId: userId,
                        AwardId: awardId
                    }, function (data) {
                        if (data != "")
                            displayNotificationMessage(data)
                        else {
                            displayNotificationMessage("The award was added!")
                            $('#modal_list_item_to_add').modal('hide')
                            getUserAwards(parentId, type)
                        }
                    }
                )
            })
        })

    $('#modal_list_item_to_add').modal('show')
}

function removeNexus() {
    let parentId = $('#modal_itemId').val()
    let type = $('#modal_itemType').val()
    let childId = $(this).parent().attr('id')
    let userId
    let awardId

    if (type == "user") {
        userId = parentId
        awardId = childId
    }
    else {
        userId = childId
        awardId = parentId
    }
    $.post("/Pages/removeNexus.cshtml",
        {
            UserId: userId,
            AwardId: awardId
        }, function (data) {
            displayNotificationMessage("The award has been removed!")
            getUserAwards(parentId, type)
        });
}

function getUserAwards(id, type) {
    $.post("/Pages/modalList.cshtml",
        {
            Id: id,
            Type: type
        },
        function (data) {
            $('#modal_user_awards').html(data)
            $('.modal_list_delete').click(removeNexus)
        })
}

function displayNotificationMessage(data) {
    $('#toast_body').html(data)
    $('.toast').toast('show')
}