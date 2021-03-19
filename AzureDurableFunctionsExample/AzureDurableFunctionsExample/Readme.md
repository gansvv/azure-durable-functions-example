Examples

###

POST http://localhost:7071/api/TriggerCreateAsset HTTP/1.1
content-type: application/json

{
	"AssetName" : "Test-Asset-6",
	"CloudPropertyName" : "Location:Seattle",
	"AssetRelationshipName" : "Gateway"
}
###

GET http://localhost:7071/runtime/webhooks/durabletask/instances/bf37094a7e874e5ca561cfc705c3d098?taskHub=CreateAssetPrototype&connection=Storage&code=OzMIO7ELafYsoNYPfbH1FCn9auP7GL3rSLMBQPj0pdG1FvIsvCfjvQ==

{
    "id": "bf37094a7e874e5ca561cfc705c3d098",
    "statusQueryGetUri": "http://localhost:7071/runtime/webhooks/durabletask/instances/bf37094a7e874e5ca561cfc705c3d098?taskHub=CreateAssetPrototype&connection=Storage&code=OzMIO7ELafYsoNYPfbH1FCn9auP7GL3rSLMBQPj0pdG1FvIsvCfjvQ==",
    "sendEventPostUri": "http://localhost:7071/runtime/webhooks/durabletask/instances/bf37094a7e874e5ca561cfc705c3d098/raiseEvent/{eventName}?taskHub=CreateAssetPrototype&connection=Storage&code=OzMIO7ELafYsoNYPfbH1FCn9auP7GL3rSLMBQPj0pdG1FvIsvCfjvQ==",
    "terminatePostUri": "http://localhost:7071/runtime/webhooks/durabletask/instances/bf37094a7e874e5ca561cfc705c3d098/terminate?reason={text}&taskHub=CreateAssetPrototype&connection=Storage&code=OzMIO7ELafYsoNYPfbH1FCn9auP7GL3rSLMBQPj0pdG1FvIsvCfjvQ==",
    "purgeHistoryDeleteUri": "http://localhost:7071/runtime/webhooks/durabletask/instances/bf37094a7e874e5ca561cfc705c3d098?taskHub=CreateAssetPrototype&connection=Storage&code=OzMIO7ELafYsoNYPfbH1FCn9auP7GL3rSLMBQPj0pdG1FvIsvCfjvQ=="
}