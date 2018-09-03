var urlBase = ""
try {
    urlBase = utils.getBaseUrl();
} catch (e) {
    console.error(e.message);
    throw new Error("El modulo utilidades es requerido");
};

window.onload = function init() {

    var $ = go.GraphObject.make;  // for conciseness in defining templates
    myDiagram = new go.Diagram("DiagramaEstructuraOrganizacional");
    myDiagram.initialContentAlignment = go.Spot.TopCenter;
    myDiagram.model = go.GraphObject.make(go.TreeModel,
      {
          nodeKeyProperty: "Id_Empleado",
          nodeParentKeyProperty: "Id_Jefe",
      });
    myDiagram.layout =
$(go.TreeLayout,
{
    angle: 90
});

    // define the Link template
    myDiagram.linkTemplate =
      $(go.Link, go.Link.Orthogonal,
        {
            corner: 10,
            relinkableFrom: true, relinkableTo: false
        },
        $(go.Shape, {
            strokeWidth: 2,
            stroke: "#ff7500"
        }));

    myDiagram.nodeTemplate =
$(go.Node, go.Panel.Auto,
$(go.Shape,
{
    strokeWidth: 4,
    figure: "RoundedRectangle",
    fill: "#7E8A97",
    stroke: "whitesmoke"
}),
$(go.Panel, go.Panel.Horizontal,
//$(go.TextBlock,
//{ margin: 10 }, // some room around the text
//new go.Binding("text", "Nombre_Empleado")
//),
$(go.TextBlock,
{ margin: 10, font: "bold 15px Helvetica, bold Arial, sans-serif", stroke: "whitesmoke", margin: 12, opacity: 0.85 }, // some room around the text
new go.Binding("text", "Cargo_Empleado"))
)

);

    pintar();
}

function pintar() {
    var isede = $("#IdSede").val();
    $.ajax({
        url: urlBase + '/PlanEmergencias/PintarOrganigrama',
        data: { isede: isede },
        type: 'POST',
        success: function (result) {
            myDiagram.model.nodeDataArray = result;
        }
    });
}

