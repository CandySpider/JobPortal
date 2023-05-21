// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
i=Number(0);
$(document).ready(function () {
    $('#addButton').click(function () { 
        var newDiv = $('<div class="col-12"><label for= "SkillList_' + i + '__SkillName"> Skill Name</label> <input type = "text" class= "form-control" data-val="true" data-val-required="The SkillName field is required." id = "SkillList_' + i + '__SkillName" name = "SkillList[' + i + '].SkillName" value = "" required></div>');
        $('#skills-container').append(newDiv);
        i++;
        return false;
    });
});




