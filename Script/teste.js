namespace WebApplication1.Script
{
    public class teste
    {
    }

    function selectedOption() {

        clientNumber = document.getElementById("ClientName").value

        const rjson = fetch('/Activities/GetClientTask?id=' + clientNumber)
            .then(response => response.json())
            .then(jrs => {
                generateOption(jrs)
                document.getElementById("TaskList").style.display = "block"
            })
            .catch(err => {
                alert("Error getting the tasks.")
                console.log(err);
                throw err;
            })
    }

    function generateOption(response) {
        response.map(item => {
            let option = document.createElement("option")
            let select = document.getElementById("TaskList")
            option.text = item.Description
            option.value = item.Description
            select.appendChild(option)
        })
    }

    function digaUmOI() {
        alert("oi")
    }


}
