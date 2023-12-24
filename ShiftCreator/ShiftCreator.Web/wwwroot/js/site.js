const getShifts = () => {
    return $.ajax({
        url: "~/ShiftCreator.Core/ShiftService/GetAllShifts",
        method: "GET",
        dataType: "json"
    });
};

getShifts()
    .done((shifts) => {
        console.log("All Shfts:", shifts);
    })
    .fail((error) => {
        console.error("Error:", error);
    });
