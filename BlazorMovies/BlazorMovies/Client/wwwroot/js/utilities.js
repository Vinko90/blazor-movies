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