$(document).ready(function () {

    Charts();

});

function Charts() {
    var donutChartCanvas = $('#donutChart').get(0).getContext('2d');
    var arrayEscolasQtdCand = []
    arrayEscolasQtdCand = RetornarResidencias();

    var donutData = {
        labels: arrayEscolasQtdCand[0][0],
        datasets: [
            {
                data: arrayEscolasQtdCand[0][1],
                backgroundColor: ['#f56954', '#00a65a', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de', '#212529', '#6610f2', '#ffd65a', '#20c997'],
            }
        ]
    }
    var donutOptions = {
        maintainAspectRatio: false,
        responsive: true,
    }

    var donutChart = new Chart(donutChartCanvas, {
        type: 'doughnut',
        data: donutData,
        options: donutOptions
    });
}

function RetornarResidencias() {
    var arrayResidencias = [];
    var arrayQtdVisitas = [];
    var arrayFull = [
        [arrayResidencias, arrayQtdVisitas]
    ];
    $.ajax({
        url: "/Admin/Residencia/RetornarListaResidencias",
        type: "POST",
        async: false,
        success: function (data) {
            for (var i = 0; i < data.residencias.length; i++) {
                arrayResidencias.push(data.residencias[i].title);
                arrayQtdVisitas.push(data.qtdVisita[i]);
            }
        }
    });
    return arrayFull;
}
