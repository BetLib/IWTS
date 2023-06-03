const registration = async () => {
    var registrationContract = {
        login: $("#login").val(),
        password: $("#password").val()
    };
    var response = await fetch("http://localhost:5204/api/Registration/student",
        {
            method: "POST",
            body: JSON.stringify(registrationContract),
            headers: {
                "Content-Type": "application/json",
            }
        }
    );

}

$(document).ready(function() {
    $( "#submit" ).on("click", registration);
});

