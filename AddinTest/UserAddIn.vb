Imports SimioAPI
Imports SimioAPI.Extensions

Namespace AddinTest
    Class UserAddIn
        Implements IDesignAddIn

        ''' <summary>
        ''' Property returning the name of the add-in. This name may contain any characters and is used as the display name for the add-in in the UI.
        ''' </summary>
        Public ReadOnly Property Name As String Implements IDesignAddIn.Name
            Get
                Return "UserAddIn"
            End Get
        End Property

        ''' <summary>
        ''' Property returning a short description of what the add-in does.
        ''' </summary>
        Public ReadOnly Property Description As String Implements IDesignAddIn.Description
            Get
                Return "Description text for the 'UserAddIn' add-in."
            End Get
        End Property

        ''' <summary>
        ''' Property returning an icon to display for the add-in in the UI.
        ''' </summary>
        Public ReadOnly Property Icon As System.Drawing.Image Implements IDesignAddIn.Icon
            Get
                Return Nothing
            End Get
        End Property

        ''' <summary>
        ''' Method called when the add-in is run.
        ''' </summary>
        Public Sub Execute(context As IDesignContext) Implements IDesignAddIn.Execute
            ' Example of how to place some New fixed objects into the active model.
            ' This example code places three New fixed objects: a Source, a Server, And a Sink.
            Dim intelligentObjects As IIntelligentObjects = context.ActiveModel.Facility.IntelligentObjects
            Dim sourceObject As IFixedObject = intelligentObjects.CreateObject("Source", New FacilityLocation(-10, 0, -10))
            Dim serverObject As IFixedObject = intelligentObjects.CreateObject("Server", New FacilityLocation(0, 0, 0))
            Dim sinkObject As IFixedObject = intelligentObjects.CreateObject("Sink", New FacilityLocation(10, 0, 10))

            ' Example of how to place some New link objects into the active model (to add network paths between nodes).
            ' This example code places two New link objects: a Path connecting the Source 'output' node to the Server 'input' node,
            ' And a Path connecting the Server 'output' node to the Sink 'input' node.
            Dim sourceOutputNode As INodeObject = sourceObject.Nodes.Item(0)
            Dim serverInputNode As INodeObject = serverObject.Nodes.Item(0)
            Dim serverOutputNode As INodeObject = serverObject.Nodes.Item(1)
            Dim sinkInputNode As INodeObject = sinkObject.Nodes.Item(0)
            Dim pathObject1 As ILinkObject = intelligentObjects.CreateLink("Path", sourceOutputNode, serverInputNode, Nothing)
            Dim pathObject2 As ILinkObject = intelligentObjects.CreateLink("Path", serverOutputNode, sinkInputNode, Nothing)

            ' Example of how to edit the property of an object.
            ' This example code edits the 'ProcessingTime' property of the added Server object.
            serverObject.Properties.Item("ProcessingTime").Value = "100"
        End Sub
    End Class
End Namespace
