$(function() {
    $('input[type="submit"]').click(function() {
        $('.txtText,select').removeClass('errorinfo');
        if ($('.txtNameOfTheCompany').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtAddress').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtNatureOfBusiness').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtTotalturnover').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtTotalregularmanpower').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtContractbaselabours').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtContactPerson').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtPhoneO').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtPhoneR').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtMobile').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtFax').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtEmail').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtEmail').validateEmail({ cssclass: "errorinfo", alert: true })
            && $('.txtPosition').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtNoOfCandidates').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtAcademic').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtTechnicalOfProfessional').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtExpFrom').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtExpTo').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtIndustry').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtAgeFrom').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtAgeTo').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtPlaceofwork').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtJobdescription').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtPreferences').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtGrossSalFrom').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtGrossSalTo').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtAdditionalBenefits').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtProbabledate').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtProbabledateOfInterview').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtInterviewLocattion').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtInterviewername').validateText({ cssclass: "errorinfo", alert: true })
            && $('.txtInterviewerposition').validateText({ cssclass: "errorinfo", alert: true })
            ) {
            return true;
        }
        return false;
    });
    $('.txtTotalturnover,.txtTotalregularmanpower,.txtContractbaselabours,.txtPhoneO,.txtPhoneR,.txtMobile,.txtFax,.txtNoOfCandidates,.txtAgeFrom,.txtAgeTo,.txtGrossSalFrom,.txtGrossSalTo,.txtExpFrom,.txtExpTo,.txtProbabledate,.txtProbabledateOfInterview').bind('keypress', function(e) {
        if ((e.which > 45 && e.which < 58) || e.which == 0 || e.which == 43)
            return true;
        return false;
    });
    $('.txtProbabledate,.txtProbabledateOfInterview').datepicker({
        onSelect: function(input, inst) {
            $(this).datepicker("option", "dateFormat", "dd/mm/yy");
        }
    });
    //$('.txtProbabledate').val(getdate());
    //$('.txtProbabledateOfInterview').val(getdate());
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