$(document).ready(function() {
    $("#register-link").click(function(e) {
        e.preventDefault();
        $("#login-form").hide();
        $("#registration-form").show();
    });

    $("#login-link").click(function(e) {
        e.preventDefault();
        $("#registration-form").hide();
        $("#login-form").show();
    });

    $("#login-form form").submit(function(e) {
        e.preventDefault();
        var UserEmail = $("#email").val();
        var UserPassword = $("#password").val();
        
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44360/api/User/login',
            data: JSON.stringify({ UserEmail: UserEmail, UserPassword: UserPassword}), 
            contentType: "application/json",
            
            success: function(response) {
                // Handle a successful registration response
                alert("Welcome Back ! " + response.Message);
                console.log('Registration successful:', response);
                
                // Redirect to admin.html after successful login
                window.location.href = 'admin.html';
            },
            error: function(xhr, status, error) {
                // Handle registration error
                var errorMessage = xhr.responseText;
                alert("Wrong Password or Email.");
                console.error('Registration error:', errorMessage);
            }
        });
    });
    

    $("#registration-form form").submit(function(e) {
        e.preventDefault();
        var newUsername = $("#new-username").val();
        var newEmail = $("#new-email").val();
        var newPassword = $("#new-password").val();
        var confirmPassword = $("#confirm-password").val();

        if (newPassword !== confirmPassword) {
            alert("Passwords do not match.");
        } else {
            // Add your registration logic here
            alert("Registration successful for user: " + newUsername);
            //TODO
            // $.ajax({
            //     type: 'POST',
            //     url: 'https://localhost:44360/api/User/login',
            //     data: JSON.stringify({ UserEmail: UserEmail, UserPassword: UserPassword}), 
            //     contentType: "application/json",
                
            //     success: function(response) {
            //         // Handle a successful registration response
            //         alert("Welcome Back ! " + response.Message);
            //         console.log('Registration successful:', response);
            //     },
            //     error: function(xhr, status, error) {
            //         // Handle registration error
            //         var errorMessage = xhr.responseText;
            //         alert(errorMessage)
            //         console.error('Registration error:', errorMessage);
            //     }
            // });

            // Hide the registration form and show the login form
            $("#registration-form").hide();
            $("#login-form").show();
        }
    });
});


