$(function() {
    $('input[type="submit"]').click(function() {
        $('.txtText,select').removeClass('errorinfo');
        if ($('.txtFirstname').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtLastname').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtEmail').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtEmail').validateEmail({ cssclass: "errorinfo", alert: true })
            && $('.txtDOB').validateText({ cssclass: "errorinfo", alert: true })) {
            if ($('.CmbGender')[0].selectedIndex == 0) {
                alert("Please select Gender");
                $('.CmbGender').addClass('errorinfo');
                $('.CmbGender').focus();
                return false;
            }
            if ($('.txtOptionalEmail').validateText({ cssclass: "errorinfo", alert: true })
                && $('.txtOptionalEmail').validateEmail({ cssclass: "errorinfo", alert: true })
                && $('.txtPhoneNo').validateText({ cssclass: "errorinfo", alert: true })
                && $('.txtMobileNo').validateText({ cssclass: "errorinfo", alert: true })) {
                if ($('.CmbUGQualification')[0].selectedIndex == 0) {
                    alert("Please select your ug qualification");
                    $('.CmbUGQualification').addClass('errorinfo');
                    $('.CmbUGQualification').focus();
                    return false;
                }
                if ($('.CmbUGQualification')[0].value.toString() == "Others") {
                    if (!$('.txtUgOthers').validateText({ cssclass: "errorinfo", alert: true })) {
                        return false;
                    }
                }
                if ($('.CmbPgQualification')[0].selectedIndex == 0) {
                    alert("Please select your pg qualification");
                    $('.CmbPgQualification').addClass('errorinfo');
                    $('.CmbPgQualification').focus();
                    return false;
                }
                if ($('.CmbPgQualification')[0].value.toString() == "Others") {
                    if (!$('.txtPgOthers').validateText({ cssclass: "errorinfo", alert: true })) {
                        return false;
                    }
                }
                if ($('.CmbIndustry')[0].selectedIndex == 0) {
                    alert("Please select your industry");
                    $('.CmbIndustry').addClass('errorinfo');
                    $('.CmbIndustry').focus();
                    return false;
                }
                if ($('.CmbIndustry')[0].value.toString() == "Others") {
                    if (!$('.txtIndustryOthers').validateText({ cssclass: "errorinfo", alert: true })) {
                        return false;
                    }
                }
                if ($('.CmbFunctionalArea')[0].selectedIndex == 0) {
                    alert("Please select your functional area");
                    $('.CmbFunctionalArea').addClass('errorinfo');
                    $('.CmbFunctionalArea').focus();
                    return false;
                }
                if ($('.CmbFunctionalArea')[0].value.toString() == "Others") {
                    if (!$('.txtFunctionalOthers').validateText({ cssclass: "errorinfo", alert: true })) {
                        return false;
                    }
                }
                if ($('.txtPrimarySkillSet').validateText({ cssclass: "errorinfo", alert: true })
                    && $('.txtSecondarySkillSet').validateText({ cssclass: "errorinfo", alert: true })
                    && $('.txtRelaventExp').validateText({ cssclass: "errorinfo", alert: true })
                    && $('.txtTotalExp').validateText({ cssclass: "errorinfo", alert: true })
                    && $('.txtCurrentCTC').validateText({ cssclass: "errorinfo", alert: true })
                    && $('.txtExpectedCTC').validateText({ cssclass: "errorinfo", alert: true })) {
                    var file = $('input[type="file"]');
                    if (file.val() == "") {
                        alert("Please attach your resume");
                        $(this).addClass('errorinfo');
                        $(this).focus();
                        return false;
                    }
                    return true;
                }
            }
        }
        return false;
    });
    $('.txtDOB,.txtPhoneNo,.txtMobileNo,.txtRelaventExp,.txtTotalExp,.txtCurrentCTC,.txtExpectedCTC').bind('keypress', function(e) {
        if ((e.which > 45 && e.which < 58) || e.which == 0 || e.which == 43)
            return true;
        return false;
    });
    $('.CmbFunctionalArea').bind('change', function() {
        if ($(this).val() == "Others") {
            $('.txtFunctionalOthers').focus();
        }
    });
    $('.CmbIndustry').bind('change', function() {
        if ($(this).val() == "Others") {
            $('.txtIndustryOthers').focus();
        }
    });
    $('.CmbPgQualification').bind('change', function() {
        if ($(this).val() == "Others") {
            $('.txtPgOthers').focus();
        }
    });
    $('.txtDOB').datepicker({
        onSelect: function(input, inst) {
            $('.txtDOB').datepicker("option", "dateFormat", "dd/mm/yy");
        }
    });
    //$('.txtDOB').val(getdate());
    function getdate() {
        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth();
        curr_month++;
        var curr_year = d.getFullYear();
        var retVal = "";
        if (curr_month < 10)
            retVal += "0" + curr_month;
        else
            retVal += curr_month;
        retVal += "/";
        if (curr_date < 10)
            retVal += "0" + curr_date;
        else
            retVal += curr_date;
        retVal += "/";
        if (curr_year < 10)
            retVal += "0" + curr_year;
        else
            retVal += curr_year;
        return retVal;
    }
});