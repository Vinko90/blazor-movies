function my_function(message) {
    console.log("Utilities_Log => " + message);
}

function dotNetStaticInvocation() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount")
        .then(result => {
            console.log("Utilities_Log => Static Count: " + result);
        });
}

function dotNetInstanceInvocation(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCountAsync");
}

function initializeInactivityTimer(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 600000);
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }
}