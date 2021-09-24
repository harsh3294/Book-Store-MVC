$(document).ready(function () {
    $("#fname").blur(() => {
        validateFName();
    });
    $("#lname").blur(() => {
        validateLName();
    });
    $("#phone").blur(() => {
        validateMobile();
    });
    $("#email").blur(() => {
        validateEmail();
    });


    //$("#tb_fname").blur(() => {
    //    e_validateFName();
    //});
    //$("#tb_lname").blur(() => {
    //    e_validateLName();
    //});
    //$("#tb_mobileNo").blur(() => {
    //    e_validateMobile();
    //});
    //$("#tb_email").blur(() => {
    //    e_validateEmail();
    //});


    $("#password").keydown(() => {
        $('#password').attr('type', 'password');
    });
    $("#password").blur(() => {
        validatePassword();
    });
    $("#tb_email").blur(() => {
        l_validateEmail();
    });
    $("#tb_password").keydown(() => {
        $('#tb_password').attr('type', 'password');
    });
    $("#tb_password").blur(() => {
        l_validatePassword();
    });
    $("#showPassword").click(() => {
        showPassword();
    });
    $("#confirmPassword").keydown(() => {
        $('#confirmPassword').attr('type', 'password');
    });
    $("#confirmPassword").blur(() => {
        validateConfirmPassword();
    });
    $("#form1").submit(function () {
        let state = validate();
        console.log(state);
        if (state === true) return true;
        else return false;
    });
    //$("#update").submit(function () {
    //    let state = e_validate();
    //    console.log(state);
    //    if (state === true) return true;
    //    else return false;
    //});
    $("#form2").submit(function () {
        let state = validate2();
        console.log(state);
        if (state === true) return true;
        else return false;
    });
});
function validateFName() {
    $(".fnameError").html("");
    var fname = $("#fname").val();
    if (fname === "") {
        $(".fnameError").html("This field is required *").css({ color: "red" });
        return false;
    }
    return true;
}
function validateLName() {
    $(".lnameError").html("");
    var fname = $("#lname").val();
    if (fname === "") {
        $(".lnameError").html("This field is required *").css({ color: "red" });
        return false;
    }
    return true;
}
function validateMobile() {
    $(".mobileError").html("");
    var phoneno = new RegExp(
        /^\+?([0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{5})$/
    );
    var mobileNumber = $("#phone").val();
    if (mobileNumber === "") {
        $(".mobileError").html("This field is required *").css({ color: "red" });
        return false;
    } else {
        if (!phoneno.test(mobileNumber)) {
            $(".mobileError").html("Invalid Mobile Number").css({ color: "red" });
            return false;
        }
    }
    return true;
}
function validateEmail() {
    $(".emailError").html("");
    var email = $("#email").val();
    var emailRegEx = new RegExp(
        /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
    );
    if (email === "") {
        $(".emailError").html("This field is required *").css({ color: "red" });
        return false;
    } else {
        if (!emailRegEx.test(email)) {
            $(".emailError").html("Invalid Email Address").css({ color: "red" });
            return false;
        }
    }
    return true;
}
function validatePassword() {
    $(".passwordError").html("");
    var password = $("#password").val();
    var passwordRegEx = new RegExp(
        /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,18})/
    );
    if (password === "") {
        $(".passwordError").html("This field is required *").css({ color: "red" });
        return false;
    }
/*    //else {
    //    if (!passwordRegEx.test(password)) {
    //        return false;
    //    } else return true;
    //}*/
    return true;
}
function l_validateEmail() {
    $(".emailError").html("");
    var email = $("#tb_email").val();
    var emailRegEx = new RegExp(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/);
    if (email === "") {
        $(".emailError").html("This field is required *").css({ color: "red" });
        return false;
    } else {
        if (!emailRegEx.test(email)) {
            $(".emailError").html("Invalid Email Address").css({ color: "red" });
            return false;
        }
    }
    return true;
}
function l_validatePassword() {
    $(".passwordError").html("");
    var password = $("#tb_password").val();
    var passwordRegEx = new RegExp(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,18})/);
    if (password === "") {
        $(".passwordError").html("This field is required *").css({ color: "red" });
        return false;
    }
    //else {
    //    if (!passwordRegEx.test(password)) {
    //        return false;
    //    }
    //}
    return true;
}
function showPassword() {
    let checked = $("#showPassword").is(":checked");
    if (checked) {
        $("#password").attr("type", "text");
    } else {
        $("#password").attr("type", "password");
    }
}
function validateConfirmPassword() {
    $(".passwordError").html("");
    $(".confirmPasswordError").html("");
    validatePassword();
    var password = $("#password").val();
    var confirmpassword = $("#confirmPassword").val();
    if (confirmpassword === "") {
        $(".confirmPasswordError")
            .html("This field is required *")
            .css({ color: "red" });
        return false;
    }

    if (password !== confirmpassword) {
        $(".confirmPasswordError")
            .html("Password Doesn't Matched")
            .css({ color: "red" });
        return false;
    }
    return true;
}





function e_validateFName() {
    $(".fnameError").html("");
    var fname = $("#tb_fname").val();
    if (fname === "") {
        $(".fnameError").html("This field is required *").css({ color: "red" });
        return false;
    }
    return true;
}
function e_validateLName() {
    $(".lnameError").html("");
    var fname = $("#tb_lname").val();
    if (fname === "") {
        $(".lnameError").html("This field is required *").css({ color: "red" });
        return false;
    }
    return true;
}
function e_validateMobile() {
    $(".mobileError").html("");
    var phoneno = new RegExp(
        /^\+?([0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{5})$/
    );
    var mobileNumber = $("#tb_mobileNo").val();
    if (mobileNumber === "") {
        $(".mobileError").html("This field is required *").css({ color: "red" });
        return false;
    } else {
        if (!phoneno.test(mobileNumber)) {
            $(".mobileError").html("Invalid Mobile Number").css({ color: "red" });
            return false;
        }
    }
    return true;
}
function e_validateEmail() {
    $(".emailError").html("");
    var email = $("#tb_email").val();
    var emailRegEx = new RegExp(
        /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
    );
    if (email === "") {
        $(".emailError").html("This field is required *").css({ color: "red" });
        return false;
    } else {
        if (!emailRegEx.test(email)) {
            $(".emailError").html("Invalid Email Address").css({ color: "red" });
            return false;
        }
    }
    return true;
}

function e_validate() {
    var fname = validateFName();
    var lname = validateLName();
    var mobile = validateMobile();
    var email = validateEmail();
    if (fname && lname && mobile && email) {
        return true;
    } else {
        return false;
    }
}
function validate() {
    var fname = validateFName();
    var lname = validateLName();
    var mobile = validateMobile();
    var email = validateEmail();
    var password = validatePassword();
    var confirmPassword = validateConfirmPassword();
    console.log(fname, lname, mobile, email, password, confirmPassword);
    if (fname && lname && mobile && email && password && confirmPassword) {
        return true;
    } else {
        return false;
    }
}
function validate2() {
    var email = l_validateEmail();
    var password = l_validatePassword();

    if (email && password) {
        return true;
    } else {
        return false;
    }
}
