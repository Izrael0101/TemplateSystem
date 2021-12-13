/*
Template Name: Color Admin - Responsive Admin Dashboard Template build with Twitter Bootstrap 3.3.2
Version: 1.6.0
Author: Sean Ngu
Website: http://www.seantheme.com/color-admin-v1.6/admin/
*/

var handleFormWysihtml5 = function () {
    "use strict";
    $('#wysihtml5').wysihtml5();
};

var FormWysihtml5 = function () {
    "use strict";
    return {
        //main function
        init: function () {
            handleFormWysihtml5();
        }
    };
}();