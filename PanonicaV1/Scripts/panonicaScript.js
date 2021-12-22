$(document).ready(function () {
    

    var host = "https://" + window.location.host + "/";
    var registerEndPoint = "api/Account/Register";
    var loginEndPoint = "Token";

    var seasonsEndpoint = "/api/seasons";
    var productsEndpoint = "/api/products";
    var packagingEndpoint = "/api/packages";
    var contractsEndpoint = "/api/contracts";
    var clientCompanyEndpoint = "/api/ClientCompany"


    var token = null;
    var headers = {};


    loadAll();

    ///----------Btns----------

    $("#loginBtn").on("click", loginFunc);
    $("#registerBtn").on("click", registerFunc);
    $("#cancelBtn").on("click", cancelFunc);
    $("#regCancelBtn").on("click", cancelFunc);
    $("#headerPackages").on("click", openPackages);
    $("#headerProducts").on("click", openProducts);
    $("#prelazak").on("click", prelezakFunc);

    function loginFunc() {
        $("#logRegDiv").css("display", "none")
        $("#loginDiv").css("display", "block")
    }

    function registerFunc() {
        $("#logRegDiv").css("display", "none")
        $("#registerDiv").css("display", "block")
    }

    function cancelFunc() {
        $("#logRegDiv").css("display", "block")
        $("#registerDiv").css("display", "none")
        $("#loginDiv").css("display", "none")
    }

    function openPackages() {
        $("#dataData").hide();
        $("#addProductDiv").hide();
        $("#packagesDataData").show();
        loadAll();
    }

    function openProducts() {
        $("#dataData").show();
        $("#addProductDiv").show();
    }

    function prelezakFunc() {
        $("#page1").hide();
        $("#wrap").hide();
        $("#page2").show();
        $("#footerp2").show();
        
    }

    ///----------Register----------
    $("#registerForm").submit(function (e) {

        e.preventDefault();
        var email = $("#regUsername").val();
        var psw = $("#regPassword").val();


        var sendData = {
            "Email": email,
            "Password": psw,
            "ConfirmPassword": psw
        }

        $.ajax({
            type: "POST",
            url: host + registerEndPoint,
            data: sendData

        }).done(function (data, status) {
            $("#registerDiv").hide();
            $("#loginDiv").show();


        }).fail(function (data, status) {
            alert("Greska prilikom registracije!");
        });

    });
    //----------Login----------
    $("#loginForm").submit(function (e) {
        e.preventDefault();

        var email = $("#loginUsername").val();
        var psw = $("#loginPassword").val();
        var sendData = {
            "grant_type": "password",
            "username": email,
            "password": psw
        };

        $.ajax({
            type: "POST",
            url: host + "Token",
            data: sendData
        })
            .done(function (data, status) {
                token = data.access_token;
                $("#loginDiv").hide();
                $("#logoDiv").show();
                $("#navbarDiv").show();
                $("#productAddDiv").show();
                $("#dataData").show();
                loadAll();

            })
            .fail(function (data, status) {
                alert("Greska prilikom prijave!");
            });


    });


    //----------FORMS----------
    $("#productAddForm").submit(function (e) {
        e.preventDefault();

        if (token) {
            headers.Authorization = "Bearer " + token;
        }

        var proizvodNaziv = $("#productName").val();
        var proizvodDatum = $("#productDate").val();
        var proizvodCena = $("#productPrice").val();
        var proizvodKolicina = $("#productQuantity").val();
        var proizvodPakovanjeId = $("#productPackaging").val();
        var proizvodSezonaId = $("#productSeason").val();

        var sendData = {
            "Name": proizvodNaziv,
            "ProductionDate": proizvodDatum,
            "Price": proizvodCena,
            "Quantity": proizvodKolicina,
            "PackagingId": proizvodPakovanjeId,
            "SeasonId": proizvodPakovanjeId
        }

        $.ajax({
            type: "POST",
            url: host + productsEndpoint,
            data: sendData
        }).done(function (data, status) {
            Refreshtable();
        }).fail(function () {
            alert("Opet greska");
        })

       
    })
    $("body").on("click", "#deleteBtn", function () {
        var id = this.name;
        if (token) {
            headers.Authorization = "Bearer " + token;
        }

        $.ajax({
            type: "DELETE",
            url: host + productsEndpoint + "/" +  id.toString(),
            headers: headers
        }).done(function (data, status) {
            Refreshtable();
        }).fail(function (data, status) {
             alert("Greska prilikom brisanja!");

        })
    })

    //----------DATA----------
    function loadAll() {
        loadProducts();
        loadPackagesDrop();
        loadPackages();
        loadSeasons();
    }

    function loadProducts() {
        var requestUrl = host + productsEndpoint;
        $.getJSON(requestUrl, fillProducts);
    }

    function loadPackagesDrop() {
        var requestUrl = host + packagingEndpoint;
        $.getJSON(requestUrl, fillPackagesDrop);
    }

    function loadSeasons() {
        var requestUrl = host + seasonsEndpoint;
        $.getJSON(requestUrl, fillSeasonsDrop);
    }

    function loadPackages() {
        var requestUrl = host + packagingEndpoint;
        $.getJSON(requestUrl, fillPackages);
    }

    //------------------------------------------

    function fillProducts(data, status) {

        console.log(token);
        var $data = $("#dataDiv");
        $data.empty();
        var header = $("<h2>Proizvodi</h2>");



        if (status == "success") {

            console.log(data);

            $data.append(header);
            var table = $("<table border =3 class='table - responsive'></table>");
            var header = $("<th>Name</th> <th>ProductionDate</th> <th>Price</th>");
            var headrerLogged = $("<th>Name</th> <th>ProductionDate</th> <th>Price</th> <th>Quantity</th> <th>Packaging</th> <th>Season</th>");

            if (token) {
                table.append(headrerLogged);
            }
            else {
                table.append(header);

            }

            for (var i = 0; i < data.length; i++) {

                var td = "<td>";
                var tdEnd = "</td>";
                var row = "<tr>";

                if (token) {
                    var deleteBtn = "<td><button id=deleteBtn name=" + data[i].Id + ">Delete</button></td>";
                    row += td + data[i].Name + tdEnd +
                        td + data[i].ProductionDate + tdEnd +
                        td + data[i].Price + tdEnd +
                        td + data[i].Quantity + tdEnd +
                        td + data[i].PackagingName + tdEnd +
                        td + data[i].SeasonName + tdEnd + deleteBtn;
                        
                }
                else {
                    row += td + data[i].Name + tdEnd +
                        td + data[i].ProductionDate + tdEnd +
                        td + data[i].Price + tdEnd;
                }
                row += "</tr>";
                table.append(row);
            }

            $data.append(table);
        }
        else {
            alert("Greska prilikom ucitavanja!");
        }

    }

    function fillPackages(data, status) {
        console.log(token);
        var $data = $("#packagesDataDiv");
        $data.empty();
        var header = $("<h2>Ambalaze</h2>");

        console.log("Cao ovo su ambalaze")

        if (status == "success") {

            console.log(data);

            $data.append(header);
            var table = $("<table border =3 class='table - responsive'></table>");
            var header = $("<th>Name</th> <th>Material</th> <th>Price</th>");
            var headrerLogged = $("<th>Name</th> <th>Material</th> <th>Price</th> <th>Volume</th>");

            if (token) {
                table.append(headrerLogged);
            }
            else {
                table.append(header);

            }

            for (var i = 0; i < data.length; i++) {

                var td = "<td>";
                var tdEnd = "</td>";
                var row = "<tr>";

                if (token) {
                    var deleteBtn = "<td><button id=deleteBtn name=" + data[i].Id + ">Delete</button></td>";
                    row += td + data[i].Name + tdEnd +
                        td + data[i].Material + tdEnd +
                        td + data[i].Price + tdEnd +
                        td + data[i].Volume + tdEnd + deleteBtn;
                }
                else {
                    row += td + data[i].Name + tdEnd +
                        td + data[i].Material + tdEnd +
                        td + data[i].Volume + tdEnd;
                }
                row += "</tr>";
                table.append(row);
            }

            $data.append(table);
        }
        else {
            alert("Greska prilikom ucitavanja!");
        }
    }

    function fillPackagesDrop(data, status) {

        var select = $("#productPackaging");
        select.empty();

        if (status === "success") {

            for (var i = 0; i < data.length; i++) {

                var option = "<option value = " + data[i].Id + ">" + data[i].Name + "</option>";
                select.append(option);
            }

        } else {
            alert("Doslo je do greske prilikom ucitavanja proizvoda u dropdown");
        }

    }
    function fillSeasonsDrop(data, status) {

        var select = $("#productSeason");
        select.empty();

        if (status === "success") {

            for (var i = 0; i < data.length; i++) {

                var option = "<option value = " + data[i].id + ">" + data[i].Name + "</option>";
                select.append(option);
            }

        } else {
            alert("Doslo je do greske prilikom ucitavanja sezona u dropdown");
        }

    }



    


    function Refreshtable() {
        $("#productName").val("");
        $("#productDate").val("");
        $("#productPrice").val("");
        $("#productQuantity").val("");
        $("#productPackaging").val("");
        $("#productSeason").val("");
        loadAll();
    }


});