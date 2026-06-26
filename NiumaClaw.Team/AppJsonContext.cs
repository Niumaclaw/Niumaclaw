using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace NiumaClaw.Team;

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(AppConfig))]
[JsonSerializable(typeof(ChatRequest))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(ChatResponse))]
[JsonSerializable(typeof(NodeInfo))]
[JsonSerializable(typeof(CreateCompanyReq))]
[JsonSerializable(typeof(NodeInfoTemplate))]
[JsonSerializable(typeof(List<NodeInfoTemplate>))]
[JsonSerializable(typeof(Dictionary<string, NodeInfo>))]
[JsonSerializable(typeof(Dictionary<string, JsonElement>))]
[JsonSerializable(typeof(JsonElement))]
[JsonSerializable(typeof(CompanySetupResult))]
[JsonSerializable(typeof(List<JsonElement>))]
[JsonSerializable(typeof(ProjectBoard))]
[JsonSerializable(typeof(List<ProjectBoard>))]
[JsonSerializable(typeof(ProjectTask))]
[JsonSerializable(typeof(List<ProjectTask>))]
[JsonSerializable(typeof(TaskComment))]
[JsonSerializable(typeof(List<TaskComment>))]
[JsonSerializable(typeof(CompanyGoal))]
[JsonSerializable(typeof(List<CompanyGoal>))]
[JsonSerializable(typeof(OrgNodePayload))]
[JsonSerializable(typeof(List<OrgNodePayload>))]
[JsonSerializable(typeof(RoutineTrigger))]
[JsonSerializable(typeof(RoutineJob))]
[JsonSerializable(typeof(List<RoutineJob>))]
[JsonSerializable(typeof(RoutineRunRecord))]
[JsonSerializable(typeof(List<RoutineRunRecord>))]
[JsonSerializable(typeof(AgentHeartbeatStatus))]
[JsonSerializable(typeof(Dictionary<string, AgentHeartbeatStatus>))]
[JsonSerializable(typeof(RoutineAlertPayload))]
[JsonSerializable(typeof(List<RoutineAlertPayload>))]
[JsonSerializable(typeof(AgentHealthPayload))]
[JsonSerializable(typeof(AgentSupportsPayload))]
[JsonSerializable(typeof(AgentProfilePayload))]
[JsonSerializable(typeof(AgentRunPayload))]
[JsonSerializable(typeof(List<AgentRunPayload>))]
[JsonSerializable(typeof(NodeDiagnosis))]
[JsonSerializable(typeof(Dictionary<string, NodeDiagnosis>))]
[JsonSerializable(typeof(AuthCodeRequest))]
[JsonSerializable(typeof(AuthRegisterRequest))]
[JsonSerializable(typeof(AuthLoginRequest))]
[JsonSerializable(typeof(AuthResetPasswordRequest))]
[JsonSerializable(typeof(AccountProfilePatchRequest))]
[JsonSerializable(typeof(AccountAvatarUploadRequest))]
[JsonSerializable(typeof(AccountAdminConfigPayload))]
[JsonSerializable(typeof(AccountAdminConfigResponse))]
[JsonSerializable(typeof(LocalNodeAdminConfigPayload))]
[JsonSerializable(typeof(LocalNodeAdminDisableResult))]
[JsonSerializable(typeof(List<LocalNodeAdminDisabledModel>))]
[JsonSerializable(typeof(AuthMePayload))]
[JsonSerializable(typeof(ModelEndpointConfig))]
[JsonSerializable(typeof(List<ModelEndpointConfig>))]
[JsonSerializable(typeof(List<LocalNodeModelPayload>))]
[JsonSerializable(typeof(AgentNodeRegisterRequest))]
[JsonSerializable(typeof(AgentNodeHeartbeatRequest))]
[JsonSerializable(typeof(AgentNodePollRequest))]
[JsonSerializable(typeof(AgentNodeClientPackageRequest))]
[JsonSerializable(typeof(AgentNodeJobStartRequest))]
[JsonSerializable(typeof(AgentNodeJobFinishRequest))]
[JsonSerializable(typeof(AgentNodeBindRequest))]
[JsonSerializable(typeof(AgentNodeClientPayload))]
[JsonSerializable(typeof(List<AgentNodeClientPayload>))]
[JsonSerializable(typeof(AgentNodeJobPayload))]
[JsonSerializable(typeof(AgentNodePollResponse))]
[JsonSerializable(typeof(AgentJobRecord))]
[JsonSerializable(typeof(List<AgentJobRecord>))]
[GeneratedCode("System.Text.Json.SourceGeneration", "10.0.14.15411")]
internal class AppJsonContext : JsonSerializerContext, IJsonTypeInfoResolver
{
	private JsonTypeInfo<bool>? _Boolean;

	private JsonTypeInfo<decimal>? _Decimal;

	private JsonTypeInfo<decimal?>? _NullableDecimal;

	private JsonTypeInfo<AccountAdminConfigPayload>? _AccountAdminConfigPayload;

	private JsonTypeInfo<AccountAdminConfigResponse>? _AccountAdminConfigResponse;

	private JsonTypeInfo<AccountAvatarUploadRequest>? _AccountAvatarUploadRequest;

	private JsonTypeInfo<AccountProfilePatchRequest>? _AccountProfilePatchRequest;

	private JsonTypeInfo<AgentHealthPayload>? _AgentHealthPayload;

	private JsonTypeInfo<AgentHeartbeatStatus>? _AgentHeartbeatStatus;

	private JsonTypeInfo<AgentJobRecord>? _AgentJobRecord;

	private JsonTypeInfo<AgentNodeBindRequest>? _AgentNodeBindRequest;

	private JsonTypeInfo<AgentNodeClientPackageRequest>? _AgentNodeClientPackageRequest;

	private JsonTypeInfo<AgentNodeClientPayload>? _AgentNodeClientPayload;

	private JsonTypeInfo<AgentNodeHeartbeatRequest>? _AgentNodeHeartbeatRequest;

	private JsonTypeInfo<AgentNodeJobFinishRequest>? _AgentNodeJobFinishRequest;

	private JsonTypeInfo<AgentNodeJobPayload>? _AgentNodeJobPayload;

	private JsonTypeInfo<AgentNodeJobStartRequest>? _AgentNodeJobStartRequest;

	private JsonTypeInfo<AgentNodePollRequest>? _AgentNodePollRequest;

	private JsonTypeInfo<AgentNodePollResponse>? _AgentNodePollResponse;

	private JsonTypeInfo<AgentNodeRegisterRequest>? _AgentNodeRegisterRequest;

	private JsonTypeInfo<AgentProfilePayload>? _AgentProfilePayload;

	private JsonTypeInfo<AgentRunPayload>? _AgentRunPayload;

	private JsonTypeInfo<AgentSupportsPayload>? _AgentSupportsPayload;

	private JsonTypeInfo<AppConfig>? _AppConfig;

	private JsonTypeInfo<AuthCodeRequest>? _AuthCodeRequest;

	private JsonTypeInfo<AuthLoginRequest>? _AuthLoginRequest;

	private JsonTypeInfo<AuthMePayload>? _AuthMePayload;

	private JsonTypeInfo<AuthRegisterRequest>? _AuthRegisterRequest;

	private JsonTypeInfo<AuthResetPasswordRequest>? _AuthResetPasswordRequest;

	private JsonTypeInfo<ChatRequest>? _ChatRequest;

	private JsonTypeInfo<ChatResponse>? _ChatResponse;

	private JsonTypeInfo<CompanyGoal>? _CompanyGoal;

	private JsonTypeInfo<CompanySetupResult>? _CompanySetupResult;

	private JsonTypeInfo<CreateCompanyReq>? _CreateCompanyReq;

	private JsonTypeInfo<LocalNodeAdminConfigPayload>? _LocalNodeAdminConfigPayload;

	private JsonTypeInfo<LocalNodeAdminDisabledModel>? _LocalNodeAdminDisabledModel;

	private JsonTypeInfo<LocalNodeAdminDisableResult>? _LocalNodeAdminDisableResult;

	private JsonTypeInfo<LocalNodeModelPayload>? _LocalNodeModelPayload;

	private JsonTypeInfo<ModelEndpointConfig>? _ModelEndpointConfig;

	private JsonTypeInfo<NodeDiagnosis>? _NodeDiagnosis;

	private JsonTypeInfo<NodeInfo>? _NodeInfo;

	private JsonTypeInfo<NodeInfoTemplate>? _NodeInfoTemplate;

	private JsonTypeInfo<OrgNodePayload>? _OrgNodePayload;

	private JsonTypeInfo<ProjectBoard>? _ProjectBoard;

	private JsonTypeInfo<ProjectTask>? _ProjectTask;

	private JsonTypeInfo<RoutineAlertPayload>? _RoutineAlertPayload;

	private JsonTypeInfo<RoutineJob>? _RoutineJob;

	private JsonTypeInfo<RoutineRunRecord>? _RoutineRunRecord;

	private JsonTypeInfo<RoutineTrigger>? _RoutineTrigger;

	private JsonTypeInfo<TaskComment>? _TaskComment;

	private JsonTypeInfo<Dictionary<string, AgentHeartbeatStatus>>? _DictionaryStringAgentHeartbeatStatus;

	private JsonTypeInfo<Dictionary<string, NodeDiagnosis>>? _DictionaryStringNodeDiagnosis;

	private JsonTypeInfo<Dictionary<string, NodeInfo>>? _DictionaryStringNodeInfo;

	private JsonTypeInfo<Dictionary<string, JsonElement>>? _DictionaryStringJsonElement;

	private JsonTypeInfo<List<AgentJobRecord>>? _ListAgentJobRecord;

	private JsonTypeInfo<List<AgentNodeClientPayload>>? _ListAgentNodeClientPayload;

	private JsonTypeInfo<List<AgentRunPayload>>? _ListAgentRunPayload;

	private JsonTypeInfo<List<CompanyGoal>>? _ListCompanyGoal;

	private JsonTypeInfo<List<LocalNodeAdminDisabledModel>>? _ListLocalNodeAdminDisabledModel;

	private JsonTypeInfo<List<LocalNodeModelPayload>>? _ListLocalNodeModelPayload;

	private JsonTypeInfo<List<ModelEndpointConfig>>? _ListModelEndpointConfig;

	private JsonTypeInfo<List<NodeInfoTemplate>>? _ListNodeInfoTemplate;

	private JsonTypeInfo<List<OrgNodePayload>>? _ListOrgNodePayload;

	private JsonTypeInfo<List<ProjectBoard>>? _ListProjectBoard;

	private JsonTypeInfo<List<ProjectTask>>? _ListProjectTask;

	private JsonTypeInfo<List<RoutineAlertPayload>>? _ListRoutineAlertPayload;

	private JsonTypeInfo<List<RoutineJob>>? _ListRoutineJob;

	private JsonTypeInfo<List<RoutineRunRecord>>? _ListRoutineRunRecord;

	private JsonTypeInfo<List<TaskComment>>? _ListTaskComment;

	private JsonTypeInfo<List<JsonElement>>? _ListJsonElement;

	private JsonTypeInfo<List<string>>? _ListString;

	private JsonTypeInfo<Guid>? _Guid;

	private JsonTypeInfo<JsonElement>? _JsonElement;

	private JsonTypeInfo<JsonElement?>? _NullableJsonElement;

	private JsonTypeInfo<int>? _Int32;

	private JsonTypeInfo<long>? _Int64;

	private JsonTypeInfo<string>? _String;

	private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions
	{
		PropertyNameCaseInsensitive = true
	};

	private const BindingFlags InstanceMemberBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	private static readonly JsonEncodedText PropName_config = JsonEncodedText.Encode("config");

	private static readonly JsonEncodedText PropName_models = JsonEncodedText.Encode("models");

	private static readonly JsonEncodedText PropName_contentType = JsonEncodedText.Encode("contentType");

	private static readonly JsonEncodedText PropName_base64Data = JsonEncodedText.Encode("base64Data");

	private static readonly JsonEncodedText PropName_displayName = JsonEncodedText.Encode("displayName");

	private static readonly JsonEncodedText PropName_email = JsonEncodedText.Encode("email");

	private static readonly JsonEncodedText PropName_phone = JsonEncodedText.Encode("phone");

	private static readonly JsonEncodedText PropName_code = JsonEncodedText.Encode("code");

	private static readonly JsonEncodedText PropName_oldEmailCode = JsonEncodedText.Encode("oldEmailCode");

	private static readonly JsonEncodedText PropName_oldPhoneCode = JsonEncodedText.Encode("oldPhoneCode");

	private static readonly JsonEncodedText PropName_password = JsonEncodedText.Encode("password");

	private static readonly JsonEncodedText PropName_currentPassword = JsonEncodedText.Encode("currentPassword");

	private static readonly JsonEncodedText PropName_status = JsonEncodedText.Encode("status");

	private static readonly JsonEncodedText PropName_source = JsonEncodedText.Encode("source");

	private static readonly JsonEncodedText PropName_message = JsonEncodedText.Encode("message");

	private static readonly JsonEncodedText PropName_lastSeenAt = JsonEncodedText.Encode("lastSeenAt");

	private static readonly JsonEncodedText PropName_employee = JsonEncodedText.Encode("employee");

	private static readonly JsonEncodedText PropName_last_seen_at = JsonEncodedText.Encode("last_seen_at");

	private static readonly JsonEncodedText PropName_last_status = JsonEncodedText.Encode("last_status");

	private static readonly JsonEncodedText PropName_last_message = JsonEncodedText.Encode("last_message");

	private static readonly JsonEncodedText PropName_alert_level = JsonEncodedText.Encode("alert_level");

	private static readonly JsonEncodedText PropName_id = JsonEncodedText.Encode("id");

	private static readonly JsonEncodedText PropName_accountId = JsonEncodedText.Encode("accountId");

	private static readonly JsonEncodedText PropName_nodeId = JsonEncodedText.Encode("nodeId");

	private static readonly JsonEncodedText PropName_employeeName = JsonEncodedText.Encode("employeeName");

	private static readonly JsonEncodedText PropName_adapterType = JsonEncodedText.Encode("adapterType");

	private static readonly JsonEncodedText PropName_prompt = JsonEncodedText.Encode("prompt");

	private static readonly JsonEncodedText PropName_payload = JsonEncodedText.Encode("payload");

	private static readonly JsonEncodedText PropName_result = JsonEncodedText.Encode("result");

	private static readonly JsonEncodedText PropName_error = JsonEncodedText.Encode("error");

	private static readonly JsonEncodedText PropName_boardTaskId = JsonEncodedText.Encode("boardTaskId");

	private static readonly JsonEncodedText PropName_createdAt = JsonEncodedText.Encode("createdAt");

	private static readonly JsonEncodedText PropName_startedAt = JsonEncodedText.Encode("startedAt");

	private static readonly JsonEncodedText PropName_finishedAt = JsonEncodedText.Encode("finishedAt");

	private static readonly JsonEncodedText PropName_updatedAt = JsonEncodedText.Encode("updatedAt");

	private static readonly JsonEncodedText PropName_workspacePath = JsonEncodedText.Encode("workspacePath");

	private static readonly JsonEncodedText PropName_adapterConfig = JsonEncodedText.Encode("adapterConfig");

	private static readonly JsonEncodedText PropName_deviceId = JsonEncodedText.Encode("deviceId");

	private static readonly JsonEncodedText PropName_deviceName = JsonEncodedText.Encode("deviceName");

	private static readonly JsonEncodedText PropName_platform = JsonEncodedText.Encode("platform");

	private static readonly JsonEncodedText PropName_version = JsonEncodedText.Encode("version");

	private static readonly JsonEncodedText PropName_online = JsonEncodedText.Encode("online");

	private static readonly JsonEncodedText PropName_capabilities = JsonEncodedText.Encode("capabilities");

	private static readonly JsonEncodedText PropName_ok = JsonEncodedText.Encode("ok");

	private static readonly JsonEncodedText PropName_output = JsonEncodedText.Encode("output");

	private static readonly JsonEncodedText PropName_metadata = JsonEncodedText.Encode("metadata");

	private static readonly JsonEncodedText PropName_timeoutMs = JsonEncodedText.Encode("timeoutMs");

	private static readonly JsonEncodedText PropName_job = JsonEncodedText.Encode("job");

	private static readonly JsonEncodedText PropName_user = JsonEncodedText.Encode("user");

	private static readonly JsonEncodedText PropName_role = JsonEncodedText.Encode("role");

	private static readonly JsonEncodedText PropName_workspace = JsonEncodedText.Encode("workspace");

	private static readonly JsonEncodedText PropName_identity = JsonEncodedText.Encode("identity");

	private static readonly JsonEncodedText PropName_supports = JsonEncodedText.Encode("supports");

	private static readonly JsonEncodedText PropName_tools = JsonEncodedText.Encode("tools");

	private static readonly JsonEncodedText PropName_recentMemory = JsonEncodedText.Encode("recentMemory");

	private static readonly JsonEncodedText PropName_budgetMonthly = JsonEncodedText.Encode("budgetMonthly");

	private static readonly JsonEncodedText PropName_budgetUsed = JsonEncodedText.Encode("budgetUsed");

	private static readonly JsonEncodedText PropName_reportsTo = JsonEncodedText.Encode("reportsTo");

	private static readonly JsonEncodedText PropName_health = JsonEncodedText.Encode("health");

	private static readonly JsonEncodedText PropName_runId = JsonEncodedText.Encode("runId");

	private static readonly JsonEncodedText PropName_taskText = JsonEncodedText.Encode("taskText");

	private static readonly JsonEncodedText PropName_origin = JsonEncodedText.Encode("origin");

	private static readonly JsonEncodedText PropName_finalContent = JsonEncodedText.Encode("finalContent");

	private static readonly JsonEncodedText PropName_lastError = JsonEncodedText.Encode("lastError");

	private static readonly JsonEncodedText PropName_provider = JsonEncodedText.Encode("provider");

	private static readonly JsonEncodedText PropName_model = JsonEncodedText.Encode("model");

	private static readonly JsonEncodedText PropName_inputTokens = JsonEncodedText.Encode("inputTokens");

	private static readonly JsonEncodedText PropName_outputTokens = JsonEncodedText.Encode("outputTokens");

	private static readonly JsonEncodedText PropName_estimatedCost = JsonEncodedText.Encode("estimatedCost");

	private static readonly JsonEncodedText PropName_costCurrency = JsonEncodedText.Encode("costCurrency");

	private static readonly JsonEncodedText PropName_taskId = JsonEncodedText.Encode("taskId");

	private static readonly JsonEncodedText PropName_steps = JsonEncodedText.Encode("steps");

	private static readonly JsonEncodedText PropName_artifacts = JsonEncodedText.Encode("artifacts");

	private static readonly JsonEncodedText PropName_pendingApproval = JsonEncodedText.Encode("pendingApproval");

	private static readonly JsonEncodedText PropName_approvals = JsonEncodedText.Encode("approvals");

	private static readonly JsonEncodedText PropName_runs = JsonEncodedText.Encode("runs");

	private static readonly JsonEncodedText PropName_history = JsonEncodedText.Encode("history");

	private static readonly JsonEncodedText PropName_attachments = JsonEncodedText.Encode("attachments");

	private static readonly JsonEncodedText PropName_vision = JsonEncodedText.Encode("vision");

	private static readonly JsonEncodedText PropName_CompanyProfile = JsonEncodedText.Encode("CompanyProfile");

	private static readonly JsonEncodedText PropName_CompanyName = JsonEncodedText.Encode("CompanyName");

	private static readonly JsonEncodedText PropName_HasLicense = JsonEncodedText.Encode("HasLicense");

	private static readonly JsonEncodedText PropName_MasterNodeUrl = JsonEncodedText.Encode("MasterNodeUrl");

	private static readonly JsonEncodedText PropName_PeerNodes = JsonEncodedText.Encode("PeerNodes");

	private static readonly JsonEncodedText PropName_CompanyGoals = JsonEncodedText.Encode("CompanyGoals");

	private static readonly JsonEncodedText PropName_Routines = JsonEncodedText.Encode("Routines");

	private static readonly JsonEncodedText PropName_RoutineHistory = JsonEncodedText.Encode("RoutineHistory");

	private static readonly JsonEncodedText PropName_AgentHeartbeats = JsonEncodedText.Encode("AgentHeartbeats");

	private static readonly JsonEncodedText PropName_CompanySOP = JsonEncodedText.Encode("CompanySOP");

	private static readonly JsonEncodedText PropName_Projects = JsonEncodedText.Encode("Projects");

	private static readonly JsonEncodedText PropName_channel = JsonEncodedText.Encode("channel");

	private static readonly JsonEncodedText PropName_target = JsonEncodedText.Encode("target");

	private static readonly JsonEncodedText PropName_purpose = JsonEncodedText.Encode("purpose");

	private static readonly JsonEncodedText PropName_identifier = JsonEncodedText.Encode("identifier");

	private static readonly JsonEncodedText PropName_authenticated = JsonEncodedText.Encode("authenticated");

	private static readonly JsonEncodedText PropName_avatarUrl = JsonEncodedText.Encode("avatarUrl");

	private static readonly JsonEncodedText PropName_modelIndex = JsonEncodedText.Encode("modelIndex");

	private static readonly JsonEncodedText PropName_sop = JsonEncodedText.Encode("sop");

	private static readonly JsonEncodedText PropName_caller = JsonEncodedText.Encode("caller");

	private static readonly JsonEncodedText PropName_lineageContext = JsonEncodedText.Encode("lineageContext");

	private static readonly JsonEncodedText PropName_snapshotAuditPayload = JsonEncodedText.Encode("snapshotAuditPayload");

	private static readonly JsonEncodedText PropName_type = JsonEncodedText.Encode("type");

	private static readonly JsonEncodedText PropName_content = JsonEncodedText.Encode("content");

	private static readonly JsonEncodedText PropName_title = JsonEncodedText.Encode("title");

	private static readonly JsonEncodedText PropName_description = JsonEncodedText.Encode("description");

	private static readonly JsonEncodedText PropName_Profile = JsonEncodedText.Encode("Profile");

	private static readonly JsonEncodedText PropName_Employees = JsonEncodedText.Encode("Employees");

	private static readonly JsonEncodedText PropName_Description = JsonEncodedText.Encode("Description");

	private static readonly JsonEncodedText PropName_baseUrl = JsonEncodedText.Encode("baseUrl");

	private static readonly JsonEncodedText PropName_apiKey = JsonEncodedText.Encode("apiKey");

	private static readonly JsonEncodedText PropName_port = JsonEncodedText.Encode("port");

	private static readonly JsonEncodedText PropName_peerNodes = JsonEncodedText.Encode("peerNodes");

	private static readonly JsonEncodedText PropName_configPath = JsonEncodedText.Encode("configPath");

	private static readonly JsonEncodedText PropName_endpointId = JsonEncodedText.Encode("endpointId");

	private static readonly JsonEncodedText PropName_reason = JsonEncodedText.Encode("reason");

	private static readonly JsonEncodedText PropName_checkedCount = JsonEncodedText.Encode("checkedCount");

	private static readonly JsonEncodedText PropName_disabledCount = JsonEncodedText.Encode("disabledCount");

	private static readonly JsonEncodedText PropName_disabledModels = JsonEncodedText.Encode("disabledModels");

	private static readonly JsonEncodedText PropName_summary = JsonEncodedText.Encode("summary");

	private static readonly JsonEncodedText PropName_Provider = JsonEncodedText.Encode("Provider");

	private static readonly JsonEncodedText PropName_Name = JsonEncodedText.Encode("Name");

	private static readonly JsonEncodedText PropName_Version = JsonEncodedText.Encode("Version");

	private static readonly JsonEncodedText PropName_BaseUrl = JsonEncodedText.Encode("BaseUrl");

	private static readonly JsonEncodedText PropName_ApiKey = JsonEncodedText.Encode("ApiKey");

	private static readonly JsonEncodedText PropName_Enabled = JsonEncodedText.Encode("Enabled");

	private static readonly JsonEncodedText PropName_EndpointId = JsonEncodedText.Encode("EndpointId");

	private static readonly JsonEncodedText PropName_name = JsonEncodedText.Encode("name");

	private static readonly JsonEncodedText PropName_enabled = JsonEncodedText.Encode("enabled");

	private static readonly JsonEncodedText PropName_sortOrder = JsonEncodedText.Encode("sortOrder");

	private static readonly JsonEncodedText PropName_url = JsonEncodedText.Encode("url");

	private static readonly JsonEncodedText PropName_configOk = JsonEncodedText.Encode("configOk");

	private static readonly JsonEncodedText PropName_statusOk = JsonEncodedText.Encode("statusOk");

	private static readonly JsonEncodedText PropName_suggestion = JsonEncodedText.Encode("suggestion");

	private static readonly JsonEncodedText PropName_lastCheckedAt = JsonEncodedText.Encode("lastCheckedAt");

	private static readonly JsonEncodedText PropName_logHint = JsonEncodedText.Encode("logHint");

	private static readonly JsonEncodedText PropName_restartHint = JsonEncodedText.Encode("restartHint");

	private static readonly JsonEncodedText PropName_Url = JsonEncodedText.Encode("Url");

	private static readonly JsonEncodedText PropName_Role = JsonEncodedText.Encode("Role");

	private static readonly JsonEncodedText PropName_Resume = JsonEncodedText.Encode("Resume");

	private static readonly JsonEncodedText PropName_ModelIndex = JsonEncodedText.Encode("ModelIndex");

	private static readonly JsonEncodedText PropName_AdapterType = JsonEncodedText.Encode("AdapterType");

	private static readonly JsonEncodedText PropName_AdapterConfig = JsonEncodedText.Encode("AdapterConfig");

	private static readonly JsonEncodedText PropName_Capabilities = JsonEncodedText.Encode("Capabilities");

	private static readonly JsonEncodedText PropName_ReportsTo = JsonEncodedText.Encode("ReportsTo");

	private static readonly JsonEncodedText PropName_BudgetMonthly = JsonEncodedText.Encode("BudgetMonthly");

	private static readonly JsonEncodedText PropName_BudgetUsed = JsonEncodedText.Encode("BudgetUsed");

	private static readonly JsonEncodedText PropName_BudgetSoftLimitRatio = JsonEncodedText.Encode("BudgetSoftLimitRatio");

	private static readonly JsonEncodedText PropName_BudgetHardLimitRatio = JsonEncodedText.Encode("BudgetHardLimitRatio");

	private static readonly JsonEncodedText PropName_directReports = JsonEncodedText.Encode("directReports");

	private static readonly JsonEncodedText PropName_chainOfCommand = JsonEncodedText.Encode("chainOfCommand");

	private static readonly JsonEncodedText PropName_project_name = JsonEncodedText.Encode("project_name");

	private static readonly JsonEncodedText PropName_tasks = JsonEncodedText.Encode("tasks");

	private static readonly JsonEncodedText PropName_goal_id = JsonEncodedText.Encode("goal_id");

	private static readonly JsonEncodedText PropName_project_goal = JsonEncodedText.Encode("project_goal");

	private static readonly JsonEncodedText PropName_context_summary = JsonEncodedText.Encode("context_summary");

	private static readonly JsonEncodedText PropName_assignee = JsonEncodedText.Encode("assignee");

	private static readonly JsonEncodedText PropName_update_time = JsonEncodedText.Encode("update_time");

	private static readonly JsonEncodedText PropName_priority = JsonEncodedText.Encode("priority");

	private static readonly JsonEncodedText PropName_parent_id = JsonEncodedText.Encode("parent_id");

	private static readonly JsonEncodedText PropName_checked_out_by = JsonEncodedText.Encode("checked_out_by");

	private static readonly JsonEncodedText PropName_checked_out_at = JsonEncodedText.Encode("checked_out_at");

	private static readonly JsonEncodedText PropName_blocked_reason = JsonEncodedText.Encode("blocked_reason");

	private static readonly JsonEncodedText PropName_review_required = JsonEncodedText.Encode("review_required");

	private static readonly JsonEncodedText PropName_comments = JsonEncodedText.Encode("comments");

	private static readonly JsonEncodedText PropName_phase = JsonEncodedText.Encode("phase");

	private static readonly JsonEncodedText PropName_depends_on = JsonEncodedText.Encode("depends_on");

	private static readonly JsonEncodedText PropName_deliverable = JsonEncodedText.Encode("deliverable");

	private static readonly JsonEncodedText PropName_gate = JsonEncodedText.Encode("gate");

	private static readonly JsonEncodedText PropName_routine_id = JsonEncodedText.Encode("routine_id");

	private static readonly JsonEncodedText PropName_routine_name = JsonEncodedText.Encode("routine_name");

	private static readonly JsonEncodedText PropName_consecutive_failures = JsonEncodedText.Encode("consecutive_failures");

	private static readonly JsonEncodedText PropName_last_alert_at = JsonEncodedText.Encode("last_alert_at");

	private static readonly JsonEncodedText PropName_trigger = JsonEncodedText.Encode("trigger");

	private static readonly JsonEncodedText PropName_next_run_at = JsonEncodedText.Encode("next_run_at");

	private static readonly JsonEncodedText PropName_last_run_at = JsonEncodedText.Encode("last_run_at");

	private static readonly JsonEncodedText PropName_max_retries = JsonEncodedText.Encode("max_retries");

	private static readonly JsonEncodedText PropName_retry_backoff_minutes = JsonEncodedText.Encode("retry_backoff_minutes");

	private static readonly JsonEncodedText PropName_started_at = JsonEncodedText.Encode("started_at");

	private static readonly JsonEncodedText PropName_finished_at = JsonEncodedText.Encode("finished_at");

	private static readonly JsonEncodedText PropName_error_message = JsonEncodedText.Encode("error_message");

	private static readonly JsonEncodedText PropName_trigger_kind = JsonEncodedText.Encode("trigger_kind");

	private static readonly JsonEncodedText PropName_cron_expression = JsonEncodedText.Encode("cron_expression");

	private static readonly JsonEncodedText PropName_interval_minutes = JsonEncodedText.Encode("interval_minutes");

	private static readonly JsonEncodedText PropName_author = JsonEncodedText.Encode("author");

	private static readonly JsonEncodedText PropName_timestamp = JsonEncodedText.Encode("timestamp");

	public JsonTypeInfo<bool> Boolean => _Boolean ?? (_Boolean = (JsonTypeInfo<bool>)base.Options.GetTypeInfo(typeof(bool)));

	public JsonTypeInfo<decimal> Decimal => _Decimal ?? (_Decimal = (JsonTypeInfo<decimal>)base.Options.GetTypeInfo(typeof(decimal)));

	public JsonTypeInfo<decimal?> NullableDecimal => _NullableDecimal ?? (_NullableDecimal = (JsonTypeInfo<decimal?>)base.Options.GetTypeInfo(typeof(decimal?)));

	public JsonTypeInfo<AccountAdminConfigPayload> AccountAdminConfigPayload => _AccountAdminConfigPayload ?? (_AccountAdminConfigPayload = (JsonTypeInfo<AccountAdminConfigPayload>)base.Options.GetTypeInfo(typeof(AccountAdminConfigPayload)));

	public JsonTypeInfo<AccountAdminConfigResponse> AccountAdminConfigResponse => _AccountAdminConfigResponse ?? (_AccountAdminConfigResponse = (JsonTypeInfo<AccountAdminConfigResponse>)base.Options.GetTypeInfo(typeof(AccountAdminConfigResponse)));

	public JsonTypeInfo<AccountAvatarUploadRequest> AccountAvatarUploadRequest => _AccountAvatarUploadRequest ?? (_AccountAvatarUploadRequest = (JsonTypeInfo<AccountAvatarUploadRequest>)base.Options.GetTypeInfo(typeof(AccountAvatarUploadRequest)));

	public JsonTypeInfo<AccountProfilePatchRequest> AccountProfilePatchRequest => _AccountProfilePatchRequest ?? (_AccountProfilePatchRequest = (JsonTypeInfo<AccountProfilePatchRequest>)base.Options.GetTypeInfo(typeof(AccountProfilePatchRequest)));

	public JsonTypeInfo<AgentHealthPayload> AgentHealthPayload => _AgentHealthPayload ?? (_AgentHealthPayload = (JsonTypeInfo<AgentHealthPayload>)base.Options.GetTypeInfo(typeof(AgentHealthPayload)));

	public JsonTypeInfo<AgentHeartbeatStatus> AgentHeartbeatStatus => _AgentHeartbeatStatus ?? (_AgentHeartbeatStatus = (JsonTypeInfo<AgentHeartbeatStatus>)base.Options.GetTypeInfo(typeof(AgentHeartbeatStatus)));

	public JsonTypeInfo<AgentJobRecord> AgentJobRecord => _AgentJobRecord ?? (_AgentJobRecord = (JsonTypeInfo<AgentJobRecord>)base.Options.GetTypeInfo(typeof(AgentJobRecord)));

	public JsonTypeInfo<AgentNodeBindRequest> AgentNodeBindRequest => _AgentNodeBindRequest ?? (_AgentNodeBindRequest = (JsonTypeInfo<AgentNodeBindRequest>)base.Options.GetTypeInfo(typeof(AgentNodeBindRequest)));

	public JsonTypeInfo<AgentNodeClientPackageRequest> AgentNodeClientPackageRequest => _AgentNodeClientPackageRequest ?? (_AgentNodeClientPackageRequest = (JsonTypeInfo<AgentNodeClientPackageRequest>)base.Options.GetTypeInfo(typeof(AgentNodeClientPackageRequest)));

	public JsonTypeInfo<AgentNodeClientPayload> AgentNodeClientPayload => _AgentNodeClientPayload ?? (_AgentNodeClientPayload = (JsonTypeInfo<AgentNodeClientPayload>)base.Options.GetTypeInfo(typeof(AgentNodeClientPayload)));

	public JsonTypeInfo<AgentNodeHeartbeatRequest> AgentNodeHeartbeatRequest => _AgentNodeHeartbeatRequest ?? (_AgentNodeHeartbeatRequest = (JsonTypeInfo<AgentNodeHeartbeatRequest>)base.Options.GetTypeInfo(typeof(AgentNodeHeartbeatRequest)));

	public JsonTypeInfo<AgentNodeJobFinishRequest> AgentNodeJobFinishRequest => _AgentNodeJobFinishRequest ?? (_AgentNodeJobFinishRequest = (JsonTypeInfo<AgentNodeJobFinishRequest>)base.Options.GetTypeInfo(typeof(AgentNodeJobFinishRequest)));

	public JsonTypeInfo<AgentNodeJobPayload> AgentNodeJobPayload => _AgentNodeJobPayload ?? (_AgentNodeJobPayload = (JsonTypeInfo<AgentNodeJobPayload>)base.Options.GetTypeInfo(typeof(AgentNodeJobPayload)));

	public JsonTypeInfo<AgentNodeJobStartRequest> AgentNodeJobStartRequest => _AgentNodeJobStartRequest ?? (_AgentNodeJobStartRequest = (JsonTypeInfo<AgentNodeJobStartRequest>)base.Options.GetTypeInfo(typeof(AgentNodeJobStartRequest)));

	public JsonTypeInfo<AgentNodePollRequest> AgentNodePollRequest => _AgentNodePollRequest ?? (_AgentNodePollRequest = (JsonTypeInfo<AgentNodePollRequest>)base.Options.GetTypeInfo(typeof(AgentNodePollRequest)));

	public JsonTypeInfo<AgentNodePollResponse> AgentNodePollResponse => _AgentNodePollResponse ?? (_AgentNodePollResponse = (JsonTypeInfo<AgentNodePollResponse>)base.Options.GetTypeInfo(typeof(AgentNodePollResponse)));

	public JsonTypeInfo<AgentNodeRegisterRequest> AgentNodeRegisterRequest => _AgentNodeRegisterRequest ?? (_AgentNodeRegisterRequest = (JsonTypeInfo<AgentNodeRegisterRequest>)base.Options.GetTypeInfo(typeof(AgentNodeRegisterRequest)));

	public JsonTypeInfo<AgentProfilePayload> AgentProfilePayload => _AgentProfilePayload ?? (_AgentProfilePayload = (JsonTypeInfo<AgentProfilePayload>)base.Options.GetTypeInfo(typeof(AgentProfilePayload)));

	public JsonTypeInfo<AgentRunPayload> AgentRunPayload => _AgentRunPayload ?? (_AgentRunPayload = (JsonTypeInfo<AgentRunPayload>)base.Options.GetTypeInfo(typeof(AgentRunPayload)));

	public JsonTypeInfo<AgentSupportsPayload> AgentSupportsPayload => _AgentSupportsPayload ?? (_AgentSupportsPayload = (JsonTypeInfo<AgentSupportsPayload>)base.Options.GetTypeInfo(typeof(AgentSupportsPayload)));

	public JsonTypeInfo<AppConfig> AppConfig => _AppConfig ?? (_AppConfig = (JsonTypeInfo<AppConfig>)base.Options.GetTypeInfo(typeof(AppConfig)));

	public JsonTypeInfo<AuthCodeRequest> AuthCodeRequest => _AuthCodeRequest ?? (_AuthCodeRequest = (JsonTypeInfo<AuthCodeRequest>)base.Options.GetTypeInfo(typeof(AuthCodeRequest)));

	public JsonTypeInfo<AuthLoginRequest> AuthLoginRequest => _AuthLoginRequest ?? (_AuthLoginRequest = (JsonTypeInfo<AuthLoginRequest>)base.Options.GetTypeInfo(typeof(AuthLoginRequest)));

	public JsonTypeInfo<AuthMePayload> AuthMePayload => _AuthMePayload ?? (_AuthMePayload = (JsonTypeInfo<AuthMePayload>)base.Options.GetTypeInfo(typeof(AuthMePayload)));

	public JsonTypeInfo<AuthRegisterRequest> AuthRegisterRequest => _AuthRegisterRequest ?? (_AuthRegisterRequest = (JsonTypeInfo<AuthRegisterRequest>)base.Options.GetTypeInfo(typeof(AuthRegisterRequest)));

	public JsonTypeInfo<AuthResetPasswordRequest> AuthResetPasswordRequest => _AuthResetPasswordRequest ?? (_AuthResetPasswordRequest = (JsonTypeInfo<AuthResetPasswordRequest>)base.Options.GetTypeInfo(typeof(AuthResetPasswordRequest)));

	public JsonTypeInfo<ChatRequest> ChatRequest => _ChatRequest ?? (_ChatRequest = (JsonTypeInfo<ChatRequest>)base.Options.GetTypeInfo(typeof(ChatRequest)));

	public JsonTypeInfo<ChatResponse> ChatResponse => _ChatResponse ?? (_ChatResponse = (JsonTypeInfo<ChatResponse>)base.Options.GetTypeInfo(typeof(ChatResponse)));

	public JsonTypeInfo<CompanyGoal> CompanyGoal => _CompanyGoal ?? (_CompanyGoal = (JsonTypeInfo<CompanyGoal>)base.Options.GetTypeInfo(typeof(CompanyGoal)));

	public JsonTypeInfo<CompanySetupResult> CompanySetupResult => _CompanySetupResult ?? (_CompanySetupResult = (JsonTypeInfo<CompanySetupResult>)base.Options.GetTypeInfo(typeof(CompanySetupResult)));

	public JsonTypeInfo<CreateCompanyReq> CreateCompanyReq => _CreateCompanyReq ?? (_CreateCompanyReq = (JsonTypeInfo<CreateCompanyReq>)base.Options.GetTypeInfo(typeof(CreateCompanyReq)));

	public JsonTypeInfo<LocalNodeAdminConfigPayload> LocalNodeAdminConfigPayload => _LocalNodeAdminConfigPayload ?? (_LocalNodeAdminConfigPayload = (JsonTypeInfo<LocalNodeAdminConfigPayload>)base.Options.GetTypeInfo(typeof(LocalNodeAdminConfigPayload)));

	public JsonTypeInfo<LocalNodeAdminDisabledModel> LocalNodeAdminDisabledModel => _LocalNodeAdminDisabledModel ?? (_LocalNodeAdminDisabledModel = (JsonTypeInfo<LocalNodeAdminDisabledModel>)base.Options.GetTypeInfo(typeof(LocalNodeAdminDisabledModel)));

	public JsonTypeInfo<LocalNodeAdminDisableResult> LocalNodeAdminDisableResult => _LocalNodeAdminDisableResult ?? (_LocalNodeAdminDisableResult = (JsonTypeInfo<LocalNodeAdminDisableResult>)base.Options.GetTypeInfo(typeof(LocalNodeAdminDisableResult)));

	public JsonTypeInfo<LocalNodeModelPayload> LocalNodeModelPayload => _LocalNodeModelPayload ?? (_LocalNodeModelPayload = (JsonTypeInfo<LocalNodeModelPayload>)base.Options.GetTypeInfo(typeof(LocalNodeModelPayload)));

	public JsonTypeInfo<ModelEndpointConfig> ModelEndpointConfig => _ModelEndpointConfig ?? (_ModelEndpointConfig = (JsonTypeInfo<ModelEndpointConfig>)base.Options.GetTypeInfo(typeof(ModelEndpointConfig)));

	public JsonTypeInfo<NodeDiagnosis> NodeDiagnosis => _NodeDiagnosis ?? (_NodeDiagnosis = (JsonTypeInfo<NodeDiagnosis>)base.Options.GetTypeInfo(typeof(NodeDiagnosis)));

	public JsonTypeInfo<NodeInfo> NodeInfo => _NodeInfo ?? (_NodeInfo = (JsonTypeInfo<NodeInfo>)base.Options.GetTypeInfo(typeof(NodeInfo)));

	public JsonTypeInfo<NodeInfoTemplate> NodeInfoTemplate => _NodeInfoTemplate ?? (_NodeInfoTemplate = (JsonTypeInfo<NodeInfoTemplate>)base.Options.GetTypeInfo(typeof(NodeInfoTemplate)));

	public JsonTypeInfo<OrgNodePayload> OrgNodePayload => _OrgNodePayload ?? (_OrgNodePayload = (JsonTypeInfo<OrgNodePayload>)base.Options.GetTypeInfo(typeof(OrgNodePayload)));

	public JsonTypeInfo<ProjectBoard> ProjectBoard => _ProjectBoard ?? (_ProjectBoard = (JsonTypeInfo<ProjectBoard>)base.Options.GetTypeInfo(typeof(ProjectBoard)));

	public JsonTypeInfo<ProjectTask> ProjectTask => _ProjectTask ?? (_ProjectTask = (JsonTypeInfo<ProjectTask>)base.Options.GetTypeInfo(typeof(ProjectTask)));

	public JsonTypeInfo<RoutineAlertPayload> RoutineAlertPayload => _RoutineAlertPayload ?? (_RoutineAlertPayload = (JsonTypeInfo<RoutineAlertPayload>)base.Options.GetTypeInfo(typeof(RoutineAlertPayload)));

	public JsonTypeInfo<RoutineJob> RoutineJob => _RoutineJob ?? (_RoutineJob = (JsonTypeInfo<RoutineJob>)base.Options.GetTypeInfo(typeof(RoutineJob)));

	public JsonTypeInfo<RoutineRunRecord> RoutineRunRecord => _RoutineRunRecord ?? (_RoutineRunRecord = (JsonTypeInfo<RoutineRunRecord>)base.Options.GetTypeInfo(typeof(RoutineRunRecord)));

	public JsonTypeInfo<RoutineTrigger> RoutineTrigger => _RoutineTrigger ?? (_RoutineTrigger = (JsonTypeInfo<RoutineTrigger>)base.Options.GetTypeInfo(typeof(RoutineTrigger)));

	public JsonTypeInfo<TaskComment> TaskComment => _TaskComment ?? (_TaskComment = (JsonTypeInfo<TaskComment>)base.Options.GetTypeInfo(typeof(TaskComment)));

	public JsonTypeInfo<Dictionary<string, AgentHeartbeatStatus>> DictionaryStringAgentHeartbeatStatus => _DictionaryStringAgentHeartbeatStatus ?? (_DictionaryStringAgentHeartbeatStatus = (JsonTypeInfo<Dictionary<string, AgentHeartbeatStatus>>)base.Options.GetTypeInfo(typeof(Dictionary<string, AgentHeartbeatStatus>)));

	public JsonTypeInfo<Dictionary<string, NodeDiagnosis>> DictionaryStringNodeDiagnosis => _DictionaryStringNodeDiagnosis ?? (_DictionaryStringNodeDiagnosis = (JsonTypeInfo<Dictionary<string, NodeDiagnosis>>)base.Options.GetTypeInfo(typeof(Dictionary<string, NodeDiagnosis>)));

	public JsonTypeInfo<Dictionary<string, NodeInfo>> DictionaryStringNodeInfo => _DictionaryStringNodeInfo ?? (_DictionaryStringNodeInfo = (JsonTypeInfo<Dictionary<string, NodeInfo>>)base.Options.GetTypeInfo(typeof(Dictionary<string, NodeInfo>)));

	public JsonTypeInfo<Dictionary<string, JsonElement>> DictionaryStringJsonElement => _DictionaryStringJsonElement ?? (_DictionaryStringJsonElement = (JsonTypeInfo<Dictionary<string, JsonElement>>)base.Options.GetTypeInfo(typeof(Dictionary<string, JsonElement>)));

	public JsonTypeInfo<List<AgentJobRecord>> ListAgentJobRecord => _ListAgentJobRecord ?? (_ListAgentJobRecord = (JsonTypeInfo<List<AgentJobRecord>>)base.Options.GetTypeInfo(typeof(List<AgentJobRecord>)));

	public JsonTypeInfo<List<AgentNodeClientPayload>> ListAgentNodeClientPayload => _ListAgentNodeClientPayload ?? (_ListAgentNodeClientPayload = (JsonTypeInfo<List<AgentNodeClientPayload>>)base.Options.GetTypeInfo(typeof(List<AgentNodeClientPayload>)));

	public JsonTypeInfo<List<AgentRunPayload>> ListAgentRunPayload => _ListAgentRunPayload ?? (_ListAgentRunPayload = (JsonTypeInfo<List<AgentRunPayload>>)base.Options.GetTypeInfo(typeof(List<AgentRunPayload>)));

	public JsonTypeInfo<List<CompanyGoal>> ListCompanyGoal => _ListCompanyGoal ?? (_ListCompanyGoal = (JsonTypeInfo<List<CompanyGoal>>)base.Options.GetTypeInfo(typeof(List<CompanyGoal>)));

	public JsonTypeInfo<List<LocalNodeAdminDisabledModel>> ListLocalNodeAdminDisabledModel => _ListLocalNodeAdminDisabledModel ?? (_ListLocalNodeAdminDisabledModel = (JsonTypeInfo<List<LocalNodeAdminDisabledModel>>)base.Options.GetTypeInfo(typeof(List<LocalNodeAdminDisabledModel>)));

	public JsonTypeInfo<List<LocalNodeModelPayload>> ListLocalNodeModelPayload => _ListLocalNodeModelPayload ?? (_ListLocalNodeModelPayload = (JsonTypeInfo<List<LocalNodeModelPayload>>)base.Options.GetTypeInfo(typeof(List<LocalNodeModelPayload>)));

	public JsonTypeInfo<List<ModelEndpointConfig>> ListModelEndpointConfig => _ListModelEndpointConfig ?? (_ListModelEndpointConfig = (JsonTypeInfo<List<ModelEndpointConfig>>)base.Options.GetTypeInfo(typeof(List<ModelEndpointConfig>)));

	public JsonTypeInfo<List<NodeInfoTemplate>> ListNodeInfoTemplate => _ListNodeInfoTemplate ?? (_ListNodeInfoTemplate = (JsonTypeInfo<List<NodeInfoTemplate>>)base.Options.GetTypeInfo(typeof(List<NodeInfoTemplate>)));

	public JsonTypeInfo<List<OrgNodePayload>> ListOrgNodePayload => _ListOrgNodePayload ?? (_ListOrgNodePayload = (JsonTypeInfo<List<OrgNodePayload>>)base.Options.GetTypeInfo(typeof(List<OrgNodePayload>)));

	public JsonTypeInfo<List<ProjectBoard>> ListProjectBoard => _ListProjectBoard ?? (_ListProjectBoard = (JsonTypeInfo<List<ProjectBoard>>)base.Options.GetTypeInfo(typeof(List<ProjectBoard>)));

	public JsonTypeInfo<List<ProjectTask>> ListProjectTask => _ListProjectTask ?? (_ListProjectTask = (JsonTypeInfo<List<ProjectTask>>)base.Options.GetTypeInfo(typeof(List<ProjectTask>)));

	public JsonTypeInfo<List<RoutineAlertPayload>> ListRoutineAlertPayload => _ListRoutineAlertPayload ?? (_ListRoutineAlertPayload = (JsonTypeInfo<List<RoutineAlertPayload>>)base.Options.GetTypeInfo(typeof(List<RoutineAlertPayload>)));

	public JsonTypeInfo<List<RoutineJob>> ListRoutineJob => _ListRoutineJob ?? (_ListRoutineJob = (JsonTypeInfo<List<RoutineJob>>)base.Options.GetTypeInfo(typeof(List<RoutineJob>)));

	public JsonTypeInfo<List<RoutineRunRecord>> ListRoutineRunRecord => _ListRoutineRunRecord ?? (_ListRoutineRunRecord = (JsonTypeInfo<List<RoutineRunRecord>>)base.Options.GetTypeInfo(typeof(List<RoutineRunRecord>)));

	public JsonTypeInfo<List<TaskComment>> ListTaskComment => _ListTaskComment ?? (_ListTaskComment = (JsonTypeInfo<List<TaskComment>>)base.Options.GetTypeInfo(typeof(List<TaskComment>)));

	public JsonTypeInfo<List<JsonElement>> ListJsonElement => _ListJsonElement ?? (_ListJsonElement = (JsonTypeInfo<List<JsonElement>>)base.Options.GetTypeInfo(typeof(List<JsonElement>)));

	public JsonTypeInfo<List<string>> ListString => _ListString ?? (_ListString = (JsonTypeInfo<List<string>>)base.Options.GetTypeInfo(typeof(List<string>)));

	public JsonTypeInfo<Guid> Guid => _Guid ?? (_Guid = (JsonTypeInfo<Guid>)base.Options.GetTypeInfo(typeof(Guid)));

	public JsonTypeInfo<JsonElement> JsonElement => _JsonElement ?? (_JsonElement = (JsonTypeInfo<JsonElement>)base.Options.GetTypeInfo(typeof(JsonElement)));

	public JsonTypeInfo<JsonElement?> NullableJsonElement => _NullableJsonElement ?? (_NullableJsonElement = (JsonTypeInfo<JsonElement?>)base.Options.GetTypeInfo(typeof(JsonElement?)));

	public JsonTypeInfo<int> Int32 => _Int32 ?? (_Int32 = (JsonTypeInfo<int>)base.Options.GetTypeInfo(typeof(int)));

	public JsonTypeInfo<long> Int64 => _Int64 ?? (_Int64 = (JsonTypeInfo<long>)base.Options.GetTypeInfo(typeof(long)));

	public JsonTypeInfo<string> String => _String ?? (_String = (JsonTypeInfo<string>)base.Options.GetTypeInfo(typeof(string)));

	public static AppJsonContext Default { get; } = new AppJsonContext(new JsonSerializerOptions(s_defaultOptions));

	protected override JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;

	private JsonTypeInfo<bool> Create_Boolean(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<bool> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool>(options, JsonMetadataServices.BooleanConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<decimal> Create_Decimal(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<decimal> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<decimal>(options, JsonMetadataServices.DecimalConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<decimal?> Create_NullableDecimal(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<decimal?> jsonTypeInfo))
		{
			JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<decimal>(options);
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<decimal?>(options, nullableConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<AccountAdminConfigPayload> Create_AccountAdminConfigPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AccountAdminConfigPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AccountAdminConfigPayload> objectInfo = new JsonObjectInfoValues<AccountAdminConfigPayload>
			{
				ObjectCreator = () => new AccountAdminConfigPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AccountAdminConfigPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AccountAdminConfigPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AccountAdminConfigPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AccountAdminConfigPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<AppConfig> propertyInfo = new JsonPropertyInfoValues<AppConfig>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((AccountAdminConfigPayload)obj).Config,
			Setter = delegate(object obj, AppConfig? value)
			{
				((AccountAdminConfigPayload)obj).Config = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Config",
			JsonPropertyName = "config",
			AttributeProviderFactory = () => typeof(AccountAdminConfigPayload).GetProperty("Config", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AppConfig), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<List<ModelEndpointConfig>> propertyInfo2 = new JsonPropertyInfoValues<List<ModelEndpointConfig>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((AccountAdminConfigPayload)obj).Models,
			Setter = delegate(object obj, List<ModelEndpointConfig>? value)
			{
				((AccountAdminConfigPayload)obj).Models = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Models",
			JsonPropertyName = "models",
			AttributeProviderFactory = () => typeof(AccountAdminConfigPayload).GetProperty("Models", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<ModelEndpointConfig>), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		return array;
	}

	private void AccountAdminConfigPayloadSerializeHandler(Utf8JsonWriter writer, AccountAdminConfigPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WritePropertyName(PropName_config);
		AppConfigSerializeHandler(writer, value.Config);
		writer.WritePropertyName(PropName_models);
		ListModelEndpointConfigSerializeHandler(writer, value.Models);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AccountAdminConfigResponse> Create_AccountAdminConfigResponse(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AccountAdminConfigResponse> jsonTypeInfo))
		{
			JsonObjectInfoValues<AccountAdminConfigResponse> objectInfo = new JsonObjectInfoValues<AccountAdminConfigResponse>
			{
				ObjectCreator = () => new AccountAdminConfigResponse(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AccountAdminConfigResponsePropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AccountAdminConfigResponse).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AccountAdminConfigResponseSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AccountAdminConfigResponsePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<AppConfig> propertyInfo = new JsonPropertyInfoValues<AppConfig>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountAdminConfigResponse),
			Converter = null,
			Getter = (object obj) => ((AccountAdminConfigResponse)obj).Config,
			Setter = delegate(object obj, AppConfig? value)
			{
				((AccountAdminConfigResponse)obj).Config = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Config",
			JsonPropertyName = "config",
			AttributeProviderFactory = () => typeof(AccountAdminConfigResponse).GetProperty("Config", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AppConfig), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<List<ModelEndpointConfig>> propertyInfo2 = new JsonPropertyInfoValues<List<ModelEndpointConfig>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountAdminConfigResponse),
			Converter = null,
			Getter = (object obj) => ((AccountAdminConfigResponse)obj).Models,
			Setter = delegate(object obj, List<ModelEndpointConfig>? value)
			{
				((AccountAdminConfigResponse)obj).Models = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Models",
			JsonPropertyName = "models",
			AttributeProviderFactory = () => typeof(AccountAdminConfigResponse).GetProperty("Models", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<ModelEndpointConfig>), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		return array;
	}

	private void AccountAdminConfigResponseSerializeHandler(Utf8JsonWriter writer, AccountAdminConfigResponse? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WritePropertyName(PropName_config);
		AppConfigSerializeHandler(writer, value.Config);
		writer.WritePropertyName(PropName_models);
		ListModelEndpointConfigSerializeHandler(writer, value.Models);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AccountAvatarUploadRequest> Create_AccountAvatarUploadRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AccountAvatarUploadRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AccountAvatarUploadRequest> objectInfo = new JsonObjectInfoValues<AccountAvatarUploadRequest>
			{
				ObjectCreator = () => new AccountAvatarUploadRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AccountAvatarUploadRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AccountAvatarUploadRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AccountAvatarUploadRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AccountAvatarUploadRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountAvatarUploadRequest),
			Converter = null,
			Getter = (object obj) => ((AccountAvatarUploadRequest)obj).ContentType,
			Setter = delegate(object obj, string? value)
			{
				((AccountAvatarUploadRequest)obj).ContentType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ContentType",
			JsonPropertyName = "contentType",
			AttributeProviderFactory = () => typeof(AccountAvatarUploadRequest).GetProperty("ContentType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountAvatarUploadRequest),
			Converter = null,
			Getter = (object obj) => ((AccountAvatarUploadRequest)obj).Base64Data,
			Setter = delegate(object obj, string? value)
			{
				((AccountAvatarUploadRequest)obj).Base64Data = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Base64Data",
			JsonPropertyName = "base64Data",
			AttributeProviderFactory = () => typeof(AccountAvatarUploadRequest).GetProperty("Base64Data", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		return array;
	}

	private void AccountAvatarUploadRequestSerializeHandler(Utf8JsonWriter writer, AccountAvatarUploadRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_contentType, value.ContentType);
		writer.WriteString(PropName_base64Data, value.Base64Data);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AccountProfilePatchRequest> Create_AccountProfilePatchRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AccountProfilePatchRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AccountProfilePatchRequest> objectInfo = new JsonObjectInfoValues<AccountProfilePatchRequest>
			{
				ObjectCreator = () => new AccountProfilePatchRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AccountProfilePatchRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AccountProfilePatchRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AccountProfilePatchRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[8];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).DisplayName,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).DisplayName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DisplayName",
			JsonPropertyName = "displayName",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("DisplayName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).Email,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).Email = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Email",
			JsonPropertyName = "email",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("Email", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).Phone,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).Phone = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Phone",
			JsonPropertyName = "phone",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("Phone", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).Code,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).Code = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Code",
			JsonPropertyName = "code",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("Code", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).OldEmailCode,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).OldEmailCode = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "OldEmailCode",
			JsonPropertyName = "oldEmailCode",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("OldEmailCode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).OldPhoneCode,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).OldPhoneCode = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "OldPhoneCode",
			JsonPropertyName = "oldPhoneCode",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("OldPhoneCode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).Password,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).Password = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Password",
			JsonPropertyName = "password",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("Password", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AccountProfilePatchRequest),
			Converter = null,
			Getter = (object obj) => ((AccountProfilePatchRequest)obj).CurrentPassword,
			Setter = delegate(object obj, string? value)
			{
				((AccountProfilePatchRequest)obj).CurrentPassword = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CurrentPassword",
			JsonPropertyName = "currentPassword",
			AttributeProviderFactory = () => typeof(AccountProfilePatchRequest).GetProperty("CurrentPassword", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		return array;
	}

	private void AccountProfilePatchRequestSerializeHandler(Utf8JsonWriter writer, AccountProfilePatchRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_displayName, value.DisplayName);
		writer.WriteString(PropName_email, value.Email);
		writer.WriteString(PropName_phone, value.Phone);
		writer.WriteString(PropName_code, value.Code);
		writer.WriteString(PropName_oldEmailCode, value.OldEmailCode);
		writer.WriteString(PropName_oldPhoneCode, value.OldPhoneCode);
		writer.WriteString(PropName_password, value.Password);
		writer.WriteString(PropName_currentPassword, value.CurrentPassword);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentHealthPayload> Create_AgentHealthPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentHealthPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentHealthPayload> objectInfo = new JsonObjectInfoValues<AgentHealthPayload>
			{
				ObjectCreator = () => new AgentHealthPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentHealthPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentHealthPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentHealthPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentHealthPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[4];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHealthPayload),
			Converter = null,
			Getter = (object obj) => ((AgentHealthPayload)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((AgentHealthPayload)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(AgentHealthPayload).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHealthPayload),
			Converter = null,
			Getter = (object obj) => ((AgentHealthPayload)obj).Source,
			Setter = delegate(object obj, string? value)
			{
				((AgentHealthPayload)obj).Source = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Source",
			JsonPropertyName = "source",
			AttributeProviderFactory = () => typeof(AgentHealthPayload).GetProperty("Source", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHealthPayload),
			Converter = null,
			Getter = (object obj) => ((AgentHealthPayload)obj).Message,
			Setter = delegate(object obj, string? value)
			{
				((AgentHealthPayload)obj).Message = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Message",
			JsonPropertyName = "message",
			AttributeProviderFactory = () => typeof(AgentHealthPayload).GetProperty("Message", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHealthPayload),
			Converter = null,
			Getter = (object obj) => ((AgentHealthPayload)obj).LastSeenAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentHealthPayload)obj).LastSeenAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastSeenAt",
			JsonPropertyName = "lastSeenAt",
			AttributeProviderFactory = () => typeof(AgentHealthPayload).GetProperty("LastSeenAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		return array;
	}

	private void AgentHealthPayloadSerializeHandler(Utf8JsonWriter writer, AgentHealthPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_status, value.Status);
		writer.WriteString(PropName_source, value.Source);
		writer.WriteString(PropName_message, value.Message);
		writer.WriteString(PropName_lastSeenAt, value.LastSeenAt);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentHeartbeatStatus> Create_AgentHeartbeatStatus(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentHeartbeatStatus> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentHeartbeatStatus> objectInfo = new JsonObjectInfoValues<AgentHeartbeatStatus>
			{
				ObjectCreator = () => new AgentHeartbeatStatus(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentHeartbeatStatusPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentHeartbeatStatus).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentHeartbeatStatusSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentHeartbeatStatusPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[6];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHeartbeatStatus),
			Converter = null,
			Getter = (object obj) => ((AgentHeartbeatStatus)obj).Employee,
			Setter = delegate(object obj, string? value)
			{
				((AgentHeartbeatStatus)obj).Employee = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Employee",
			JsonPropertyName = "employee",
			AttributeProviderFactory = () => typeof(AgentHeartbeatStatus).GetProperty("Employee", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHeartbeatStatus),
			Converter = null,
			Getter = (object obj) => ((AgentHeartbeatStatus)obj).LastSeenAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentHeartbeatStatus)obj).LastSeenAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastSeenAt",
			JsonPropertyName = "last_seen_at",
			AttributeProviderFactory = () => typeof(AgentHeartbeatStatus).GetProperty("LastSeenAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHeartbeatStatus),
			Converter = null,
			Getter = (object obj) => ((AgentHeartbeatStatus)obj).LastStatus,
			Setter = delegate(object obj, string? value)
			{
				((AgentHeartbeatStatus)obj).LastStatus = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastStatus",
			JsonPropertyName = "last_status",
			AttributeProviderFactory = () => typeof(AgentHeartbeatStatus).GetProperty("LastStatus", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHeartbeatStatus),
			Converter = null,
			Getter = (object obj) => ((AgentHeartbeatStatus)obj).LastMessage,
			Setter = delegate(object obj, string? value)
			{
				((AgentHeartbeatStatus)obj).LastMessage = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastMessage",
			JsonPropertyName = "last_message",
			AttributeProviderFactory = () => typeof(AgentHeartbeatStatus).GetProperty("LastMessage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHeartbeatStatus),
			Converter = null,
			Getter = (object obj) => ((AgentHeartbeatStatus)obj).Source,
			Setter = delegate(object obj, string? value)
			{
				((AgentHeartbeatStatus)obj).Source = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Source",
			JsonPropertyName = "source",
			AttributeProviderFactory = () => typeof(AgentHeartbeatStatus).GetProperty("Source", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentHeartbeatStatus),
			Converter = null,
			Getter = (object obj) => ((AgentHeartbeatStatus)obj).AlertLevel,
			Setter = delegate(object obj, string? value)
			{
				((AgentHeartbeatStatus)obj).AlertLevel = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AlertLevel",
			JsonPropertyName = "alert_level",
			AttributeProviderFactory = () => typeof(AgentHeartbeatStatus).GetProperty("AlertLevel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		return array;
	}

	private void AgentHeartbeatStatusSerializeHandler(Utf8JsonWriter writer, AgentHeartbeatStatus? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_employee, value.Employee);
		writer.WriteString(PropName_last_seen_at, value.LastSeenAt);
		writer.WriteString(PropName_last_status, value.LastStatus);
		writer.WriteString(PropName_last_message, value.LastMessage);
		writer.WriteString(PropName_source, value.Source);
		writer.WriteString(PropName_alert_level, value.AlertLevel);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentJobRecord> Create_AgentJobRecord(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentJobRecord> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentJobRecord> objectInfo = new JsonObjectInfoValues<AgentJobRecord>
			{
				ObjectCreator = () => new AgentJobRecord(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentJobRecordPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentJobRecord).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentJobRecordSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentJobRecordPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[15];
		JsonPropertyInfoValues<long> propertyInfo = new JsonPropertyInfoValues<long>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).Id,
			Setter = delegate(object obj, long value)
			{
				((AgentJobRecord)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(long), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<Guid> propertyInfo2 = new JsonPropertyInfoValues<Guid>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).AccountId,
			Setter = delegate(object obj, Guid value)
			{
				((AgentJobRecord)obj).AccountId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AccountId",
			JsonPropertyName = "accountId",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("AccountId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Guid), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<long> propertyInfo3 = new JsonPropertyInfoValues<long>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).NodeId,
			Setter = delegate(object obj, long value)
			{
				((AgentJobRecord)obj).NodeId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "NodeId",
			JsonPropertyName = "nodeId",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("NodeId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(long), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).EmployeeName,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).EmployeeName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EmployeeName",
			JsonPropertyName = "employeeName",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("EmployeeName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "adapterType",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).Prompt,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).Prompt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Prompt",
			JsonPropertyName = "prompt",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("Prompt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		JsonPropertyInfoValues<JsonElement> propertyInfo8 = new JsonPropertyInfoValues<JsonElement>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).Payload,
			Setter = delegate(object obj, JsonElement value)
			{
				((AgentJobRecord)obj).Payload = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Payload",
			JsonPropertyName = "payload",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("Payload", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).Result,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).Result = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Result",
			JsonPropertyName = "result",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("Result", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).Error,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).Error = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Error",
			JsonPropertyName = "error",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("Error", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		JsonPropertyInfoValues<string> propertyInfo11 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).BoardTaskId,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).BoardTaskId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BoardTaskId",
			JsonPropertyName = "boardTaskId",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("BoardTaskId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).CreatedAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).CreatedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CreatedAt",
			JsonPropertyName = "createdAt",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("CreatedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
		JsonPropertyInfoValues<string> propertyInfo13 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).StartedAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).StartedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "StartedAt",
			JsonPropertyName = "startedAt",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("StartedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
		JsonPropertyInfoValues<string> propertyInfo14 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).FinishedAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).FinishedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "FinishedAt",
			JsonPropertyName = "finishedAt",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("FinishedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
		JsonPropertyInfoValues<string> propertyInfo15 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentJobRecord),
			Converter = null,
			Getter = (object obj) => ((AgentJobRecord)obj).UpdatedAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentJobRecord)obj).UpdatedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "UpdatedAt",
			JsonPropertyName = "updatedAt",
			AttributeProviderFactory = () => typeof(AgentJobRecord).GetProperty("UpdatedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
		return array;
	}

	private void AgentJobRecordSerializeHandler(Utf8JsonWriter writer, AgentJobRecord? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteNumber(PropName_id, value.Id);
		writer.WriteString(PropName_accountId, value.AccountId);
		writer.WriteNumber(PropName_nodeId, value.NodeId);
		writer.WriteString(PropName_employeeName, value.EmployeeName);
		writer.WriteString(PropName_adapterType, value.AdapterType);
		writer.WriteString(PropName_status, value.Status);
		writer.WriteString(PropName_prompt, value.Prompt);
		writer.WritePropertyName(PropName_payload);
		JsonSerializer.Serialize(writer, value.Payload, JsonElement);
		writer.WriteString(PropName_result, value.Result);
		writer.WriteString(PropName_error, value.Error);
		writer.WriteString(PropName_boardTaskId, value.BoardTaskId);
		writer.WriteString(PropName_createdAt, value.CreatedAt);
		writer.WriteString(PropName_startedAt, value.StartedAt);
		writer.WriteString(PropName_finishedAt, value.FinishedAt);
		writer.WriteString(PropName_updatedAt, value.UpdatedAt);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeBindRequest> Create_AgentNodeBindRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeBindRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeBindRequest> objectInfo = new JsonObjectInfoValues<AgentNodeBindRequest>
			{
				ObjectCreator = () => new AgentNodeBindRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeBindRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeBindRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeBindRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeBindRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeBindRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeBindRequest)obj).EmployeeName,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeBindRequest)obj).EmployeeName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EmployeeName",
			JsonPropertyName = "employeeName",
			AttributeProviderFactory = () => typeof(AgentNodeBindRequest).GetProperty("EmployeeName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<long> propertyInfo2 = new JsonPropertyInfoValues<long>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeBindRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeBindRequest)obj).NodeId,
			Setter = delegate(object obj, long value)
			{
				((AgentNodeBindRequest)obj).NodeId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "NodeId",
			JsonPropertyName = "nodeId",
			AttributeProviderFactory = () => typeof(AgentNodeBindRequest).GetProperty("NodeId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(long), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeBindRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeBindRequest)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeBindRequest)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "adapterType",
			AttributeProviderFactory = () => typeof(AgentNodeBindRequest).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeBindRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeBindRequest)obj).WorkspacePath,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeBindRequest)obj).WorkspacePath = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "WorkspacePath",
			JsonPropertyName = "workspacePath",
			AttributeProviderFactory = () => typeof(AgentNodeBindRequest).GetProperty("WorkspacePath", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<Dictionary<string, JsonElement>> propertyInfo5 = new JsonPropertyInfoValues<Dictionary<string, JsonElement>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeBindRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeBindRequest)obj).AdapterConfig,
			Setter = delegate(object obj, Dictionary<string, JsonElement>? value)
			{
				((AgentNodeBindRequest)obj).AdapterConfig = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterConfig",
			JsonPropertyName = "adapterConfig",
			AttributeProviderFactory = () => typeof(AgentNodeBindRequest).GetProperty("AdapterConfig", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, JsonElement>), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		return array;
	}

	private void AgentNodeBindRequestSerializeHandler(Utf8JsonWriter writer, AgentNodeBindRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_employeeName, value.EmployeeName);
		writer.WriteNumber(PropName_nodeId, value.NodeId);
		writer.WriteString(PropName_adapterType, value.AdapterType);
		writer.WriteString(PropName_workspacePath, value.WorkspacePath);
		writer.WritePropertyName(PropName_adapterConfig);
		DictionaryStringJsonElementSerializeHandler(writer, value.AdapterConfig);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeClientPackageRequest> Create_AgentNodeClientPackageRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeClientPackageRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeClientPackageRequest> objectInfo = new JsonObjectInfoValues<AgentNodeClientPackageRequest>
			{
				ObjectCreator = () => new AgentNodeClientPackageRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeClientPackageRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeClientPackageRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeClientPackageRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeClientPackageRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[4];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPackageRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPackageRequest)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPackageRequest)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "adapterType",
			AttributeProviderFactory = () => typeof(AgentNodeClientPackageRequest).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPackageRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPackageRequest)obj).WorkspacePath,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPackageRequest)obj).WorkspacePath = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "WorkspacePath",
			JsonPropertyName = "workspacePath",
			AttributeProviderFactory = () => typeof(AgentNodeClientPackageRequest).GetProperty("WorkspacePath", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPackageRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPackageRequest)obj).DeviceId,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPackageRequest)obj).DeviceId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DeviceId",
			JsonPropertyName = "deviceId",
			AttributeProviderFactory = () => typeof(AgentNodeClientPackageRequest).GetProperty("DeviceId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPackageRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPackageRequest)obj).DeviceName,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPackageRequest)obj).DeviceName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DeviceName",
			JsonPropertyName = "deviceName",
			AttributeProviderFactory = () => typeof(AgentNodeClientPackageRequest).GetProperty("DeviceName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		return array;
	}

	private void AgentNodeClientPackageRequestSerializeHandler(Utf8JsonWriter writer, AgentNodeClientPackageRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_adapterType, value.AdapterType);
		writer.WriteString(PropName_workspacePath, value.WorkspacePath);
		writer.WriteString(PropName_deviceId, value.DeviceId);
		writer.WriteString(PropName_deviceName, value.DeviceName);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeClientPayload> Create_AgentNodeClientPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeClientPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeClientPayload> objectInfo = new JsonObjectInfoValues<AgentNodeClientPayload>
			{
				ObjectCreator = () => new AgentNodeClientPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeClientPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeClientPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeClientPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[9];
		JsonPropertyInfoValues<long> propertyInfo = new JsonPropertyInfoValues<long>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).Id,
			Setter = delegate(object obj, long value)
			{
				((AgentNodeClientPayload)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(long), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).DeviceId,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPayload)obj).DeviceId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DeviceId",
			JsonPropertyName = "deviceId",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("DeviceId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).DeviceName,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPayload)obj).DeviceName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DeviceName",
			JsonPropertyName = "deviceName",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("DeviceName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).Platform,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPayload)obj).Platform = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Platform",
			JsonPropertyName = "platform",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("Platform", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).Version,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPayload)obj).Version = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Version",
			JsonPropertyName = "version",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("Version", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPayload)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo7 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).Online,
			Setter = delegate(object obj, bool value)
			{
				((AgentNodeClientPayload)obj).Online = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Online",
			JsonPropertyName = "online",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("Online", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).LastSeenAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeClientPayload)obj).LastSeenAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastSeenAt",
			JsonPropertyName = "lastSeenAt",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("LastSeenAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<Dictionary<string, JsonElement>> propertyInfo9 = new JsonPropertyInfoValues<Dictionary<string, JsonElement>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeClientPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeClientPayload)obj).Capabilities,
			Setter = delegate(object obj, Dictionary<string, JsonElement>? value)
			{
				((AgentNodeClientPayload)obj).Capabilities = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Capabilities",
			JsonPropertyName = "capabilities",
			AttributeProviderFactory = () => typeof(AgentNodeClientPayload).GetProperty("Capabilities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, JsonElement>), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		return array;
	}

	private void AgentNodeClientPayloadSerializeHandler(Utf8JsonWriter writer, AgentNodeClientPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteNumber(PropName_id, value.Id);
		writer.WriteString(PropName_deviceId, value.DeviceId);
		writer.WriteString(PropName_deviceName, value.DeviceName);
		writer.WriteString(PropName_platform, value.Platform);
		writer.WriteString(PropName_version, value.Version);
		writer.WriteString(PropName_status, value.Status);
		writer.WriteBoolean(PropName_online, value.Online);
		writer.WriteString(PropName_lastSeenAt, value.LastSeenAt);
		writer.WritePropertyName(PropName_capabilities);
		DictionaryStringJsonElementSerializeHandler(writer, value.Capabilities);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeHeartbeatRequest> Create_AgentNodeHeartbeatRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeHeartbeatRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeHeartbeatRequest> objectInfo = new JsonObjectInfoValues<AgentNodeHeartbeatRequest>
			{
				ObjectCreator = () => new AgentNodeHeartbeatRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeHeartbeatRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeHeartbeatRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeHeartbeatRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeHeartbeatRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[3];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeHeartbeatRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeHeartbeatRequest)obj).Platform,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeHeartbeatRequest)obj).Platform = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Platform",
			JsonPropertyName = "platform",
			AttributeProviderFactory = () => typeof(AgentNodeHeartbeatRequest).GetProperty("Platform", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeHeartbeatRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeHeartbeatRequest)obj).Version,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeHeartbeatRequest)obj).Version = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Version",
			JsonPropertyName = "version",
			AttributeProviderFactory = () => typeof(AgentNodeHeartbeatRequest).GetProperty("Version", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<Dictionary<string, JsonElement>> propertyInfo3 = new JsonPropertyInfoValues<Dictionary<string, JsonElement>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeHeartbeatRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeHeartbeatRequest)obj).Capabilities,
			Setter = delegate(object obj, Dictionary<string, JsonElement>? value)
			{
				((AgentNodeHeartbeatRequest)obj).Capabilities = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Capabilities",
			JsonPropertyName = "capabilities",
			AttributeProviderFactory = () => typeof(AgentNodeHeartbeatRequest).GetProperty("Capabilities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, JsonElement>), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		return array;
	}

	private void AgentNodeHeartbeatRequestSerializeHandler(Utf8JsonWriter writer, AgentNodeHeartbeatRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_platform, value.Platform);
		writer.WriteString(PropName_version, value.Version);
		writer.WritePropertyName(PropName_capabilities);
		DictionaryStringJsonElementSerializeHandler(writer, value.Capabilities);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeJobFinishRequest> Create_AgentNodeJobFinishRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeJobFinishRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeJobFinishRequest> objectInfo = new JsonObjectInfoValues<AgentNodeJobFinishRequest>
			{
				ObjectCreator = () => new AgentNodeJobFinishRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeJobFinishRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeJobFinishRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeJobFinishRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeJobFinishRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[4];
		JsonPropertyInfoValues<bool> propertyInfo = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobFinishRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobFinishRequest)obj).Ok,
			Setter = delegate(object obj, bool value)
			{
				((AgentNodeJobFinishRequest)obj).Ok = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Ok",
			JsonPropertyName = "ok",
			AttributeProviderFactory = () => typeof(AgentNodeJobFinishRequest).GetProperty("Ok", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobFinishRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobFinishRequest)obj).Output,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobFinishRequest)obj).Output = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Output",
			JsonPropertyName = "output",
			AttributeProviderFactory = () => typeof(AgentNodeJobFinishRequest).GetProperty("Output", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobFinishRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobFinishRequest)obj).Error,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobFinishRequest)obj).Error = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Error",
			JsonPropertyName = "error",
			AttributeProviderFactory = () => typeof(AgentNodeJobFinishRequest).GetProperty("Error", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<JsonElement?> propertyInfo4 = new JsonPropertyInfoValues<JsonElement?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobFinishRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobFinishRequest)obj).Metadata,
			Setter = delegate(object obj, JsonElement? value)
			{
				((AgentNodeJobFinishRequest)obj).Metadata = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Metadata",
			JsonPropertyName = "metadata",
			AttributeProviderFactory = () => typeof(AgentNodeJobFinishRequest).GetProperty("Metadata", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement?), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		return array;
	}

	private void AgentNodeJobFinishRequestSerializeHandler(Utf8JsonWriter writer, AgentNodeJobFinishRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteBoolean(PropName_ok, value.Ok);
		writer.WriteString(PropName_output, value.Output);
		writer.WriteString(PropName_error, value.Error);
		writer.WritePropertyName(PropName_metadata);
		JsonSerializer.Serialize(writer, value.Metadata, NullableJsonElement);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeJobPayload> Create_AgentNodeJobPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeJobPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeJobPayload> objectInfo = new JsonObjectInfoValues<AgentNodeJobPayload>
			{
				ObjectCreator = () => new AgentNodeJobPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeJobPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeJobPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeJobPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[8];
		JsonPropertyInfoValues<long> propertyInfo = new JsonPropertyInfoValues<long>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).Id,
			Setter = delegate(object obj, long value)
			{
				((AgentNodeJobPayload)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(long), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).AccountId,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobPayload)obj).AccountId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AccountId",
			JsonPropertyName = "accountId",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("AccountId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).EmployeeName,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobPayload)obj).EmployeeName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EmployeeName",
			JsonPropertyName = "employeeName",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("EmployeeName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobPayload)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "adapterType",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).Prompt,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobPayload)obj).Prompt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Prompt",
			JsonPropertyName = "prompt",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("Prompt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<JsonElement> propertyInfo6 = new JsonPropertyInfoValues<JsonElement>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).Payload,
			Setter = delegate(object obj, JsonElement value)
			{
				((AgentNodeJobPayload)obj).Payload = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Payload",
			JsonPropertyName = "payload",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("Payload", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).BoardTaskId,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobPayload)obj).BoardTaskId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BoardTaskId",
			JsonPropertyName = "boardTaskId",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("BoardTaskId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobPayload),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobPayload)obj).CreatedAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobPayload)obj).CreatedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CreatedAt",
			JsonPropertyName = "createdAt",
			AttributeProviderFactory = () => typeof(AgentNodeJobPayload).GetProperty("CreatedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		array[7].IsGetNullable = false;
		array[7].IsSetNullable = false;
		return array;
	}

	private void AgentNodeJobPayloadSerializeHandler(Utf8JsonWriter writer, AgentNodeJobPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteNumber(PropName_id, value.Id);
		writer.WriteString(PropName_accountId, value.AccountId);
		writer.WriteString(PropName_employeeName, value.EmployeeName);
		writer.WriteString(PropName_adapterType, value.AdapterType);
		writer.WriteString(PropName_prompt, value.Prompt);
		writer.WritePropertyName(PropName_payload);
		JsonSerializer.Serialize(writer, value.Payload, JsonElement);
		writer.WriteString(PropName_boardTaskId, value.BoardTaskId);
		writer.WriteString(PropName_createdAt, value.CreatedAt);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeJobStartRequest> Create_AgentNodeJobStartRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeJobStartRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeJobStartRequest> objectInfo = new JsonObjectInfoValues<AgentNodeJobStartRequest>
			{
				ObjectCreator = () => new AgentNodeJobStartRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeJobStartRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeJobStartRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeJobStartRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeJobStartRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[1];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeJobStartRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeJobStartRequest)obj).Message,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeJobStartRequest)obj).Message = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Message",
			JsonPropertyName = "message",
			AttributeProviderFactory = () => typeof(AgentNodeJobStartRequest).GetProperty("Message", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		return array;
	}

	private void AgentNodeJobStartRequestSerializeHandler(Utf8JsonWriter writer, AgentNodeJobStartRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_message, value.Message);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodePollRequest> Create_AgentNodePollRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodePollRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodePollRequest> objectInfo = new JsonObjectInfoValues<AgentNodePollRequest>
			{
				ObjectCreator = () => new AgentNodePollRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodePollRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodePollRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodePollRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodePollRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<int> propertyInfo = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodePollRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodePollRequest)obj).TimeoutMs,
			Setter = delegate(object obj, int value)
			{
				((AgentNodePollRequest)obj).TimeoutMs = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "TimeoutMs",
			JsonPropertyName = "timeoutMs",
			AttributeProviderFactory = () => typeof(AgentNodePollRequest).GetProperty("TimeoutMs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<Dictionary<string, JsonElement>> propertyInfo2 = new JsonPropertyInfoValues<Dictionary<string, JsonElement>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodePollRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodePollRequest)obj).Capabilities,
			Setter = delegate(object obj, Dictionary<string, JsonElement>? value)
			{
				((AgentNodePollRequest)obj).Capabilities = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Capabilities",
			JsonPropertyName = "capabilities",
			AttributeProviderFactory = () => typeof(AgentNodePollRequest).GetProperty("Capabilities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, JsonElement>), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		return array;
	}

	private void AgentNodePollRequestSerializeHandler(Utf8JsonWriter writer, AgentNodePollRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteNumber(PropName_timeoutMs, value.TimeoutMs);
		writer.WritePropertyName(PropName_capabilities);
		DictionaryStringJsonElementSerializeHandler(writer, value.Capabilities);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodePollResponse> Create_AgentNodePollResponse(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodePollResponse> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodePollResponse> objectInfo = new JsonObjectInfoValues<AgentNodePollResponse>
			{
				ObjectCreator = () => new AgentNodePollResponse(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodePollResponsePropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodePollResponse).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodePollResponseSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodePollResponsePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[1];
		JsonPropertyInfoValues<AgentNodeJobPayload> propertyInfo = new JsonPropertyInfoValues<AgentNodeJobPayload>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodePollResponse),
			Converter = null,
			Getter = (object obj) => ((AgentNodePollResponse)obj).Job,
			Setter = delegate(object obj, AgentNodeJobPayload? value)
			{
				((AgentNodePollResponse)obj).Job = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Job",
			JsonPropertyName = "job",
			AttributeProviderFactory = () => typeof(AgentNodePollResponse).GetProperty("Job", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AgentNodeJobPayload), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		return array;
	}

	private void AgentNodePollResponseSerializeHandler(Utf8JsonWriter writer, AgentNodePollResponse? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WritePropertyName(PropName_job);
		AgentNodeJobPayloadSerializeHandler(writer, value.Job);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentNodeRegisterRequest> Create_AgentNodeRegisterRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentNodeRegisterRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentNodeRegisterRequest> objectInfo = new JsonObjectInfoValues<AgentNodeRegisterRequest>
			{
				ObjectCreator = () => new AgentNodeRegisterRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentNodeRegisterRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentNodeRegisterRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentNodeRegisterRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentNodeRegisterRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeRegisterRequest)obj).DeviceId,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeRegisterRequest)obj).DeviceId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DeviceId",
			JsonPropertyName = "deviceId",
			AttributeProviderFactory = () => typeof(AgentNodeRegisterRequest).GetProperty("DeviceId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeRegisterRequest)obj).DeviceName,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeRegisterRequest)obj).DeviceName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DeviceName",
			JsonPropertyName = "deviceName",
			AttributeProviderFactory = () => typeof(AgentNodeRegisterRequest).GetProperty("DeviceName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeRegisterRequest)obj).Platform,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeRegisterRequest)obj).Platform = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Platform",
			JsonPropertyName = "platform",
			AttributeProviderFactory = () => typeof(AgentNodeRegisterRequest).GetProperty("Platform", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeRegisterRequest)obj).Version,
			Setter = delegate(object obj, string? value)
			{
				((AgentNodeRegisterRequest)obj).Version = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Version",
			JsonPropertyName = "version",
			AttributeProviderFactory = () => typeof(AgentNodeRegisterRequest).GetProperty("Version", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<Dictionary<string, JsonElement>> propertyInfo5 = new JsonPropertyInfoValues<Dictionary<string, JsonElement>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentNodeRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AgentNodeRegisterRequest)obj).Capabilities,
			Setter = delegate(object obj, Dictionary<string, JsonElement>? value)
			{
				((AgentNodeRegisterRequest)obj).Capabilities = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Capabilities",
			JsonPropertyName = "capabilities",
			AttributeProviderFactory = () => typeof(AgentNodeRegisterRequest).GetProperty("Capabilities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, JsonElement>), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		return array;
	}

	private void AgentNodeRegisterRequestSerializeHandler(Utf8JsonWriter writer, AgentNodeRegisterRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_deviceId, value.DeviceId);
		writer.WriteString(PropName_deviceName, value.DeviceName);
		writer.WriteString(PropName_platform, value.Platform);
		writer.WriteString(PropName_version, value.Version);
		writer.WritePropertyName(PropName_capabilities);
		DictionaryStringJsonElementSerializeHandler(writer, value.Capabilities);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentProfilePayload> Create_AgentProfilePayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentProfilePayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentProfilePayload> objectInfo = new JsonObjectInfoValues<AgentProfilePayload>
			{
				ObjectCreator = () => new AgentProfilePayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentProfilePayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentProfilePayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentProfilePayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentProfilePayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[13];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).User,
			Setter = delegate(object obj, string? value)
			{
				((AgentProfilePayload)obj).User = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "User",
			JsonPropertyName = "user",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("User", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((AgentProfilePayload)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "adapterType",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).Role,
			Setter = delegate(object obj, string? value)
			{
				((AgentProfilePayload)obj).Role = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Role",
			JsonPropertyName = "role",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("Role", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).Workspace,
			Setter = delegate(object obj, string? value)
			{
				((AgentProfilePayload)obj).Workspace = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Workspace",
			JsonPropertyName = "workspace",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("Workspace", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).Identity,
			Setter = delegate(object obj, string? value)
			{
				((AgentProfilePayload)obj).Identity = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Identity",
			JsonPropertyName = "identity",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("Identity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<List<string>> propertyInfo6 = new JsonPropertyInfoValues<List<string>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).Capabilities,
			Setter = delegate(object obj, List<string>? value)
			{
				((AgentProfilePayload)obj).Capabilities = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Capabilities",
			JsonPropertyName = "capabilities",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("Capabilities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<AgentSupportsPayload> propertyInfo7 = new JsonPropertyInfoValues<AgentSupportsPayload>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).Supports,
			Setter = delegate(object obj, AgentSupportsPayload? value)
			{
				((AgentProfilePayload)obj).Supports = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Supports",
			JsonPropertyName = "supports",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("Supports", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AgentSupportsPayload), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		JsonPropertyInfoValues<JsonElement> propertyInfo8 = new JsonPropertyInfoValues<JsonElement>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).Tools,
			Setter = delegate(object obj, JsonElement value)
			{
				((AgentProfilePayload)obj).Tools = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Tools",
			JsonPropertyName = "tools",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("Tools", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<JsonElement> propertyInfo9 = new JsonPropertyInfoValues<JsonElement>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).RecentMemory,
			Setter = delegate(object obj, JsonElement value)
			{
				((AgentProfilePayload)obj).RecentMemory = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RecentMemory",
			JsonPropertyName = "recentMemory",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("RecentMemory", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		JsonPropertyInfoValues<decimal> propertyInfo10 = new JsonPropertyInfoValues<decimal>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).BudgetMonthly,
			Setter = delegate(object obj, decimal value)
			{
				((AgentProfilePayload)obj).BudgetMonthly = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BudgetMonthly",
			JsonPropertyName = "budgetMonthly",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("BudgetMonthly", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(decimal), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		JsonPropertyInfoValues<decimal> propertyInfo11 = new JsonPropertyInfoValues<decimal>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).BudgetUsed,
			Setter = delegate(object obj, decimal value)
			{
				((AgentProfilePayload)obj).BudgetUsed = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BudgetUsed",
			JsonPropertyName = "budgetUsed",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("BudgetUsed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(decimal), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).ReportsTo,
			Setter = delegate(object obj, string? value)
			{
				((AgentProfilePayload)obj).ReportsTo = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ReportsTo",
			JsonPropertyName = "reportsTo",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("ReportsTo", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
		array[11].IsGetNullable = false;
		array[11].IsSetNullable = false;
		JsonPropertyInfoValues<AgentHealthPayload> propertyInfo13 = new JsonPropertyInfoValues<AgentHealthPayload>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentProfilePayload),
			Converter = null,
			Getter = (object obj) => ((AgentProfilePayload)obj).Health,
			Setter = delegate(object obj, AgentHealthPayload? value)
			{
				((AgentProfilePayload)obj).Health = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Health",
			JsonPropertyName = "health",
			AttributeProviderFactory = () => typeof(AgentProfilePayload).GetProperty("Health", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AgentHealthPayload), Array.Empty<Type>(), null)
		};
		array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
		array[12].IsGetNullable = false;
		array[12].IsSetNullable = false;
		return array;
	}

	private void AgentProfilePayloadSerializeHandler(Utf8JsonWriter writer, AgentProfilePayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_user, value.User);
		writer.WriteString(PropName_adapterType, value.AdapterType);
		writer.WriteString(PropName_role, value.Role);
		writer.WriteString(PropName_workspace, value.Workspace);
		writer.WriteString(PropName_identity, value.Identity);
		writer.WritePropertyName(PropName_capabilities);
		ListStringSerializeHandler(writer, value.Capabilities);
		writer.WritePropertyName(PropName_supports);
		AgentSupportsPayloadSerializeHandler(writer, value.Supports);
		writer.WritePropertyName(PropName_tools);
		JsonSerializer.Serialize(writer, value.Tools, JsonElement);
		writer.WritePropertyName(PropName_recentMemory);
		JsonSerializer.Serialize(writer, value.RecentMemory, JsonElement);
		writer.WriteNumber(PropName_budgetMonthly, value.BudgetMonthly);
		writer.WriteNumber(PropName_budgetUsed, value.BudgetUsed);
		writer.WriteString(PropName_reportsTo, value.ReportsTo);
		writer.WritePropertyName(PropName_health);
		AgentHealthPayloadSerializeHandler(writer, value.Health);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentRunPayload> Create_AgentRunPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentRunPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentRunPayload> objectInfo = new JsonObjectInfoValues<AgentRunPayload>
			{
				ObjectCreator = () => new AgentRunPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentRunPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentRunPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentRunPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentRunPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[22];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).RunId,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).RunId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RunId",
			JsonPropertyName = "runId",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("RunId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).User,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).User = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "User",
			JsonPropertyName = "user",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("User", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Role,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).Role = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Role",
			JsonPropertyName = "role",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Role", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).TaskText,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).TaskText = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "TaskText",
			JsonPropertyName = "taskText",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("TaskText", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Origin,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).Origin = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Origin",
			JsonPropertyName = "origin",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Origin", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Workspace,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).Workspace = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Workspace",
			JsonPropertyName = "workspace",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Workspace", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).CreatedAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).CreatedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CreatedAt",
			JsonPropertyName = "createdAt",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("CreatedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		array[7].IsGetNullable = false;
		array[7].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).UpdatedAt,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).UpdatedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "UpdatedAt",
			JsonPropertyName = "updatedAt",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("UpdatedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		array[8].IsGetNullable = false;
		array[8].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).FinalContent,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).FinalContent = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "FinalContent",
			JsonPropertyName = "finalContent",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("FinalContent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		array[9].IsGetNullable = false;
		array[9].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo11 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).LastError,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).LastError = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastError",
			JsonPropertyName = "lastError",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("LastError", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		array[10].IsGetNullable = false;
		array[10].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Provider,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).Provider = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Provider",
			JsonPropertyName = "provider",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Provider", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
		array[11].IsGetNullable = false;
		array[11].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo13 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Model,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).Model = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Model",
			JsonPropertyName = "model",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Model", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
		array[12].IsGetNullable = false;
		array[12].IsSetNullable = false;
		JsonPropertyInfoValues<int> propertyInfo14 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).InputTokens,
			Setter = delegate(object obj, int value)
			{
				((AgentRunPayload)obj).InputTokens = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "InputTokens",
			JsonPropertyName = "inputTokens",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("InputTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
		JsonPropertyInfoValues<int> propertyInfo15 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).OutputTokens,
			Setter = delegate(object obj, int value)
			{
				((AgentRunPayload)obj).OutputTokens = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "OutputTokens",
			JsonPropertyName = "outputTokens",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("OutputTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
		JsonPropertyInfoValues<decimal> propertyInfo16 = new JsonPropertyInfoValues<decimal>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).EstimatedCost,
			Setter = delegate(object obj, decimal value)
			{
				((AgentRunPayload)obj).EstimatedCost = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EstimatedCost",
			JsonPropertyName = "estimatedCost",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("EstimatedCost", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(decimal), Array.Empty<Type>(), null)
		};
		array[15] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo16);
		JsonPropertyInfoValues<string> propertyInfo17 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).CostCurrency,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).CostCurrency = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CostCurrency",
			JsonPropertyName = "costCurrency",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("CostCurrency", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[16] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo17);
		array[16].IsGetNullable = false;
		array[16].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo18 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).TaskId,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).TaskId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "TaskId",
			JsonPropertyName = "taskId",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("TaskId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[17] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo18);
		array[17].IsGetNullable = false;
		array[17].IsSetNullable = false;
		JsonPropertyInfoValues<JsonElement> propertyInfo19 = new JsonPropertyInfoValues<JsonElement>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Steps,
			Setter = delegate(object obj, JsonElement value)
			{
				((AgentRunPayload)obj).Steps = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Steps",
			JsonPropertyName = "steps",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Steps", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement), Array.Empty<Type>(), null)
		};
		array[18] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo19);
		JsonPropertyInfoValues<JsonElement> propertyInfo20 = new JsonPropertyInfoValues<JsonElement>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).Artifacts,
			Setter = delegate(object obj, JsonElement value)
			{
				((AgentRunPayload)obj).Artifacts = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Artifacts",
			JsonPropertyName = "artifacts",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("Artifacts", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement), Array.Empty<Type>(), null)
		};
		array[19] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo20);
		JsonPropertyInfoValues<JsonElement> propertyInfo21 = new JsonPropertyInfoValues<JsonElement>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).PendingApproval,
			Setter = delegate(object obj, JsonElement value)
			{
				((AgentRunPayload)obj).PendingApproval = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "PendingApproval",
			JsonPropertyName = "pendingApproval",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("PendingApproval", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement), Array.Empty<Type>(), null)
		};
		array[20] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo21);
		JsonPropertyInfoValues<string> propertyInfo22 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentRunPayload),
			Converter = null,
			Getter = (object obj) => ((AgentRunPayload)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((AgentRunPayload)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "adapterType",
			AttributeProviderFactory = () => typeof(AgentRunPayload).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[21] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo22);
		array[21].IsGetNullable = false;
		array[21].IsSetNullable = false;
		return array;
	}

	private void AgentRunPayloadSerializeHandler(Utf8JsonWriter writer, AgentRunPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_runId, value.RunId);
		writer.WriteString(PropName_user, value.User);
		writer.WriteString(PropName_role, value.Role);
		writer.WriteString(PropName_taskText, value.TaskText);
		writer.WriteString(PropName_status, value.Status);
		writer.WriteString(PropName_origin, value.Origin);
		writer.WriteString(PropName_workspace, value.Workspace);
		writer.WriteString(PropName_createdAt, value.CreatedAt);
		writer.WriteString(PropName_updatedAt, value.UpdatedAt);
		writer.WriteString(PropName_finalContent, value.FinalContent);
		writer.WriteString(PropName_lastError, value.LastError);
		writer.WriteString(PropName_provider, value.Provider);
		writer.WriteString(PropName_model, value.Model);
		writer.WriteNumber(PropName_inputTokens, value.InputTokens);
		writer.WriteNumber(PropName_outputTokens, value.OutputTokens);
		writer.WriteNumber(PropName_estimatedCost, value.EstimatedCost);
		writer.WriteString(PropName_costCurrency, value.CostCurrency);
		writer.WriteString(PropName_taskId, value.TaskId);
		writer.WritePropertyName(PropName_steps);
		JsonSerializer.Serialize(writer, value.Steps, JsonElement);
		writer.WritePropertyName(PropName_artifacts);
		JsonSerializer.Serialize(writer, value.Artifacts, JsonElement);
		writer.WritePropertyName(PropName_pendingApproval);
		JsonSerializer.Serialize(writer, value.PendingApproval, JsonElement);
		writer.WriteString(PropName_adapterType, value.AdapterType);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AgentSupportsPayload> Create_AgentSupportsPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AgentSupportsPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AgentSupportsPayload> objectInfo = new JsonObjectInfoValues<AgentSupportsPayload>
			{
				ObjectCreator = () => new AgentSupportsPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AgentSupportsPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AgentSupportsPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AgentSupportsPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AgentSupportsPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<bool> propertyInfo = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentSupportsPayload),
			Converter = null,
			Getter = (object obj) => ((AgentSupportsPayload)obj).Approvals,
			Setter = delegate(object obj, bool value)
			{
				((AgentSupportsPayload)obj).Approvals = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Approvals",
			JsonPropertyName = "approvals",
			AttributeProviderFactory = () => typeof(AgentSupportsPayload).GetProperty("Approvals", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<bool> propertyInfo2 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentSupportsPayload),
			Converter = null,
			Getter = (object obj) => ((AgentSupportsPayload)obj).Runs,
			Setter = delegate(object obj, bool value)
			{
				((AgentSupportsPayload)obj).Runs = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Runs",
			JsonPropertyName = "runs",
			AttributeProviderFactory = () => typeof(AgentSupportsPayload).GetProperty("Runs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<bool> propertyInfo3 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentSupportsPayload),
			Converter = null,
			Getter = (object obj) => ((AgentSupportsPayload)obj).History,
			Setter = delegate(object obj, bool value)
			{
				((AgentSupportsPayload)obj).History = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "History",
			JsonPropertyName = "history",
			AttributeProviderFactory = () => typeof(AgentSupportsPayload).GetProperty("History", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<bool> propertyInfo4 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentSupportsPayload),
			Converter = null,
			Getter = (object obj) => ((AgentSupportsPayload)obj).Attachments,
			Setter = delegate(object obj, bool value)
			{
				((AgentSupportsPayload)obj).Attachments = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Attachments",
			JsonPropertyName = "attachments",
			AttributeProviderFactory = () => typeof(AgentSupportsPayload).GetProperty("Attachments", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<bool> propertyInfo5 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AgentSupportsPayload),
			Converter = null,
			Getter = (object obj) => ((AgentSupportsPayload)obj).Vision,
			Setter = delegate(object obj, bool value)
			{
				((AgentSupportsPayload)obj).Vision = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Vision",
			JsonPropertyName = "vision",
			AttributeProviderFactory = () => typeof(AgentSupportsPayload).GetProperty("Vision", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		return array;
	}

	private void AgentSupportsPayloadSerializeHandler(Utf8JsonWriter writer, AgentSupportsPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteBoolean(PropName_approvals, value.Approvals);
		writer.WriteBoolean(PropName_runs, value.Runs);
		writer.WriteBoolean(PropName_history, value.History);
		writer.WriteBoolean(PropName_attachments, value.Attachments);
		writer.WriteBoolean(PropName_vision, value.Vision);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AppConfig> Create_AppConfig(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AppConfig> jsonTypeInfo))
		{
			JsonObjectInfoValues<AppConfig> objectInfo = new JsonObjectInfoValues<AppConfig>
			{
				ObjectCreator = () => new AppConfig(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AppConfigPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AppConfig).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AppConfigSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AppConfigPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[11];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).CompanyProfile,
			Setter = delegate(object obj, string? value)
			{
				((AppConfig)obj).CompanyProfile = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CompanyProfile",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("CompanyProfile", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).CompanyName,
			Setter = delegate(object obj, string? value)
			{
				((AppConfig)obj).CompanyName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CompanyName",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("CompanyName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo3 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).HasLicense,
			Setter = delegate(object obj, bool value)
			{
				((AppConfig)obj).HasLicense = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "HasLicense",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("HasLicense", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).MasterNodeUrl,
			Setter = delegate(object obj, string? value)
			{
				((AppConfig)obj).MasterNodeUrl = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "MasterNodeUrl",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("MasterNodeUrl", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<Dictionary<string, NodeInfo>> propertyInfo5 = new JsonPropertyInfoValues<Dictionary<string, NodeInfo>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).PeerNodes,
			Setter = delegate(object obj, Dictionary<string, NodeInfo>? value)
			{
				((AppConfig)obj).PeerNodes = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "PeerNodes",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("PeerNodes", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, NodeInfo>), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<List<CompanyGoal>> propertyInfo6 = new JsonPropertyInfoValues<List<CompanyGoal>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).CompanyGoals,
			Setter = delegate(object obj, List<CompanyGoal>? value)
			{
				((AppConfig)obj).CompanyGoals = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CompanyGoals",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("CompanyGoals", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<CompanyGoal>), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<List<RoutineJob>> propertyInfo7 = new JsonPropertyInfoValues<List<RoutineJob>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).Routines,
			Setter = delegate(object obj, List<RoutineJob>? value)
			{
				((AppConfig)obj).Routines = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Routines",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("Routines", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<RoutineJob>), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		JsonPropertyInfoValues<List<RoutineRunRecord>> propertyInfo8 = new JsonPropertyInfoValues<List<RoutineRunRecord>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).RoutineHistory,
			Setter = delegate(object obj, List<RoutineRunRecord>? value)
			{
				((AppConfig)obj).RoutineHistory = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RoutineHistory",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("RoutineHistory", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<RoutineRunRecord>), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		array[7].IsGetNullable = false;
		array[7].IsSetNullable = false;
		JsonPropertyInfoValues<Dictionary<string, AgentHeartbeatStatus>> propertyInfo9 = new JsonPropertyInfoValues<Dictionary<string, AgentHeartbeatStatus>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).AgentHeartbeats,
			Setter = delegate(object obj, Dictionary<string, AgentHeartbeatStatus>? value)
			{
				((AppConfig)obj).AgentHeartbeats = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AgentHeartbeats",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("AgentHeartbeats", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, AgentHeartbeatStatus>), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		array[8].IsGetNullable = false;
		array[8].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).CompanySOP,
			Setter = delegate(object obj, string? value)
			{
				((AppConfig)obj).CompanySOP = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CompanySOP",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("CompanySOP", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		JsonPropertyInfoValues<List<ProjectBoard>> propertyInfo11 = new JsonPropertyInfoValues<List<ProjectBoard>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AppConfig),
			Converter = null,
			Getter = (object obj) => ((AppConfig)obj).Projects,
			Setter = delegate(object obj, List<ProjectBoard>? value)
			{
				((AppConfig)obj).Projects = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Projects",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(AppConfig).GetProperty("Projects", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<ProjectBoard>), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		array[10].IsGetNullable = false;
		array[10].IsSetNullable = false;
		return array;
	}

	private void AppConfigSerializeHandler(Utf8JsonWriter writer, AppConfig? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_CompanyProfile, value.CompanyProfile);
		writer.WriteString(PropName_CompanyName, value.CompanyName);
		writer.WriteBoolean(PropName_HasLicense, value.HasLicense);
		writer.WriteString(PropName_MasterNodeUrl, value.MasterNodeUrl);
		writer.WritePropertyName(PropName_PeerNodes);
		DictionaryStringNodeInfoSerializeHandler(writer, value.PeerNodes);
		writer.WritePropertyName(PropName_CompanyGoals);
		ListCompanyGoalSerializeHandler(writer, value.CompanyGoals);
		writer.WritePropertyName(PropName_Routines);
		ListRoutineJobSerializeHandler(writer, value.Routines);
		writer.WritePropertyName(PropName_RoutineHistory);
		ListRoutineRunRecordSerializeHandler(writer, value.RoutineHistory);
		writer.WritePropertyName(PropName_AgentHeartbeats);
		DictionaryStringAgentHeartbeatStatusSerializeHandler(writer, value.AgentHeartbeats);
		writer.WriteString(PropName_CompanySOP, value.CompanySOP);
		writer.WritePropertyName(PropName_Projects);
		ListProjectBoardSerializeHandler(writer, value.Projects);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AuthCodeRequest> Create_AuthCodeRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AuthCodeRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AuthCodeRequest> objectInfo = new JsonObjectInfoValues<AuthCodeRequest>
			{
				ObjectCreator = () => new AuthCodeRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AuthCodeRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AuthCodeRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AuthCodeRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AuthCodeRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[3];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthCodeRequest),
			Converter = null,
			Getter = (object obj) => ((AuthCodeRequest)obj).Channel,
			Setter = delegate(object obj, string? value)
			{
				((AuthCodeRequest)obj).Channel = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Channel",
			JsonPropertyName = "channel",
			AttributeProviderFactory = () => typeof(AuthCodeRequest).GetProperty("Channel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthCodeRequest),
			Converter = null,
			Getter = (object obj) => ((AuthCodeRequest)obj).Target,
			Setter = delegate(object obj, string? value)
			{
				((AuthCodeRequest)obj).Target = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Target",
			JsonPropertyName = "target",
			AttributeProviderFactory = () => typeof(AuthCodeRequest).GetProperty("Target", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthCodeRequest),
			Converter = null,
			Getter = (object obj) => ((AuthCodeRequest)obj).Purpose,
			Setter = delegate(object obj, string? value)
			{
				((AuthCodeRequest)obj).Purpose = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Purpose",
			JsonPropertyName = "purpose",
			AttributeProviderFactory = () => typeof(AuthCodeRequest).GetProperty("Purpose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		return array;
	}

	private void AuthCodeRequestSerializeHandler(Utf8JsonWriter writer, AuthCodeRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_channel, value.Channel);
		writer.WriteString(PropName_target, value.Target);
		writer.WriteString(PropName_purpose, value.Purpose);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AuthLoginRequest> Create_AuthLoginRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AuthLoginRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AuthLoginRequest> objectInfo = new JsonObjectInfoValues<AuthLoginRequest>
			{
				ObjectCreator = () => new AuthLoginRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AuthLoginRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AuthLoginRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AuthLoginRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AuthLoginRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[3];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthLoginRequest),
			Converter = null,
			Getter = (object obj) => ((AuthLoginRequest)obj).Identifier,
			Setter = delegate(object obj, string? value)
			{
				((AuthLoginRequest)obj).Identifier = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Identifier",
			JsonPropertyName = "identifier",
			AttributeProviderFactory = () => typeof(AuthLoginRequest).GetProperty("Identifier", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthLoginRequest),
			Converter = null,
			Getter = (object obj) => ((AuthLoginRequest)obj).Code,
			Setter = delegate(object obj, string? value)
			{
				((AuthLoginRequest)obj).Code = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Code",
			JsonPropertyName = "code",
			AttributeProviderFactory = () => typeof(AuthLoginRequest).GetProperty("Code", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthLoginRequest),
			Converter = null,
			Getter = (object obj) => ((AuthLoginRequest)obj).Password,
			Setter = delegate(object obj, string? value)
			{
				((AuthLoginRequest)obj).Password = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Password",
			JsonPropertyName = "password",
			AttributeProviderFactory = () => typeof(AuthLoginRequest).GetProperty("Password", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		return array;
	}

	private void AuthLoginRequestSerializeHandler(Utf8JsonWriter writer, AuthLoginRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_identifier, value.Identifier);
		writer.WriteString(PropName_code, value.Code);
		writer.WriteString(PropName_password, value.Password);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AuthMePayload> Create_AuthMePayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AuthMePayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<AuthMePayload> objectInfo = new JsonObjectInfoValues<AuthMePayload>
			{
				ObjectCreator = () => new AuthMePayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AuthMePayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AuthMePayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AuthMePayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AuthMePayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[6];
		JsonPropertyInfoValues<bool> propertyInfo = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthMePayload),
			Converter = null,
			Getter = (object obj) => ((AuthMePayload)obj).Authenticated,
			Setter = delegate(object obj, bool value)
			{
				((AuthMePayload)obj).Authenticated = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Authenticated",
			JsonPropertyName = "authenticated",
			AttributeProviderFactory = () => typeof(AuthMePayload).GetProperty("Authenticated", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthMePayload),
			Converter = null,
			Getter = (object obj) => ((AuthMePayload)obj).AccountId,
			Setter = delegate(object obj, string? value)
			{
				((AuthMePayload)obj).AccountId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AccountId",
			JsonPropertyName = "accountId",
			AttributeProviderFactory = () => typeof(AuthMePayload).GetProperty("AccountId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthMePayload),
			Converter = null,
			Getter = (object obj) => ((AuthMePayload)obj).Email,
			Setter = delegate(object obj, string? value)
			{
				((AuthMePayload)obj).Email = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Email",
			JsonPropertyName = "email",
			AttributeProviderFactory = () => typeof(AuthMePayload).GetProperty("Email", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthMePayload),
			Converter = null,
			Getter = (object obj) => ((AuthMePayload)obj).Phone,
			Setter = delegate(object obj, string? value)
			{
				((AuthMePayload)obj).Phone = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Phone",
			JsonPropertyName = "phone",
			AttributeProviderFactory = () => typeof(AuthMePayload).GetProperty("Phone", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthMePayload),
			Converter = null,
			Getter = (object obj) => ((AuthMePayload)obj).DisplayName,
			Setter = delegate(object obj, string? value)
			{
				((AuthMePayload)obj).DisplayName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DisplayName",
			JsonPropertyName = "displayName",
			AttributeProviderFactory = () => typeof(AuthMePayload).GetProperty("DisplayName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthMePayload),
			Converter = null,
			Getter = (object obj) => ((AuthMePayload)obj).AvatarUrl,
			Setter = delegate(object obj, string? value)
			{
				((AuthMePayload)obj).AvatarUrl = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AvatarUrl",
			JsonPropertyName = "avatarUrl",
			AttributeProviderFactory = () => typeof(AuthMePayload).GetProperty("AvatarUrl", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		return array;
	}

	private void AuthMePayloadSerializeHandler(Utf8JsonWriter writer, AuthMePayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteBoolean(PropName_authenticated, value.Authenticated);
		writer.WriteString(PropName_accountId, value.AccountId);
		writer.WriteString(PropName_email, value.Email);
		writer.WriteString(PropName_phone, value.Phone);
		writer.WriteString(PropName_displayName, value.DisplayName);
		writer.WriteString(PropName_avatarUrl, value.AvatarUrl);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AuthRegisterRequest> Create_AuthRegisterRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AuthRegisterRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AuthRegisterRequest> objectInfo = new JsonObjectInfoValues<AuthRegisterRequest>
			{
				ObjectCreator = () => new AuthRegisterRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AuthRegisterRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AuthRegisterRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AuthRegisterRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AuthRegisterRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AuthRegisterRequest)obj).Email,
			Setter = delegate(object obj, string? value)
			{
				((AuthRegisterRequest)obj).Email = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Email",
			JsonPropertyName = "email",
			AttributeProviderFactory = () => typeof(AuthRegisterRequest).GetProperty("Email", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AuthRegisterRequest)obj).Phone,
			Setter = delegate(object obj, string? value)
			{
				((AuthRegisterRequest)obj).Phone = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Phone",
			JsonPropertyName = "phone",
			AttributeProviderFactory = () => typeof(AuthRegisterRequest).GetProperty("Phone", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AuthRegisterRequest)obj).Code,
			Setter = delegate(object obj, string? value)
			{
				((AuthRegisterRequest)obj).Code = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Code",
			JsonPropertyName = "code",
			AttributeProviderFactory = () => typeof(AuthRegisterRequest).GetProperty("Code", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AuthRegisterRequest)obj).Password,
			Setter = delegate(object obj, string? value)
			{
				((AuthRegisterRequest)obj).Password = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Password",
			JsonPropertyName = "password",
			AttributeProviderFactory = () => typeof(AuthRegisterRequest).GetProperty("Password", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthRegisterRequest),
			Converter = null,
			Getter = (object obj) => ((AuthRegisterRequest)obj).DisplayName,
			Setter = delegate(object obj, string? value)
			{
				((AuthRegisterRequest)obj).DisplayName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DisplayName",
			JsonPropertyName = "displayName",
			AttributeProviderFactory = () => typeof(AuthRegisterRequest).GetProperty("DisplayName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		return array;
	}

	private void AuthRegisterRequestSerializeHandler(Utf8JsonWriter writer, AuthRegisterRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_email, value.Email);
		writer.WriteString(PropName_phone, value.Phone);
		writer.WriteString(PropName_code, value.Code);
		writer.WriteString(PropName_password, value.Password);
		writer.WriteString(PropName_displayName, value.DisplayName);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<AuthResetPasswordRequest> Create_AuthResetPasswordRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AuthResetPasswordRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<AuthResetPasswordRequest> objectInfo = new JsonObjectInfoValues<AuthResetPasswordRequest>
			{
				ObjectCreator = () => new AuthResetPasswordRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => AuthResetPasswordRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(AuthResetPasswordRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = AuthResetPasswordRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] AuthResetPasswordRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[3];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthResetPasswordRequest),
			Converter = null,
			Getter = (object obj) => ((AuthResetPasswordRequest)obj).Identifier,
			Setter = delegate(object obj, string? value)
			{
				((AuthResetPasswordRequest)obj).Identifier = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Identifier",
			JsonPropertyName = "identifier",
			AttributeProviderFactory = () => typeof(AuthResetPasswordRequest).GetProperty("Identifier", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthResetPasswordRequest),
			Converter = null,
			Getter = (object obj) => ((AuthResetPasswordRequest)obj).Code,
			Setter = delegate(object obj, string? value)
			{
				((AuthResetPasswordRequest)obj).Code = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Code",
			JsonPropertyName = "code",
			AttributeProviderFactory = () => typeof(AuthResetPasswordRequest).GetProperty("Code", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(AuthResetPasswordRequest),
			Converter = null,
			Getter = (object obj) => ((AuthResetPasswordRequest)obj).Password,
			Setter = delegate(object obj, string? value)
			{
				((AuthResetPasswordRequest)obj).Password = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Password",
			JsonPropertyName = "password",
			AttributeProviderFactory = () => typeof(AuthResetPasswordRequest).GetProperty("Password", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		return array;
	}

	private void AuthResetPasswordRequestSerializeHandler(Utf8JsonWriter writer, AuthResetPasswordRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_identifier, value.Identifier);
		writer.WriteString(PropName_code, value.Code);
		writer.WriteString(PropName_password, value.Password);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<ChatRequest> Create_ChatRequest(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatRequest> jsonTypeInfo))
		{
			JsonObjectInfoValues<ChatRequest> objectInfo = new JsonObjectInfoValues<ChatRequest>
			{
				ObjectCreator = () => new ChatRequest(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => ChatRequestPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(ChatRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = ChatRequestSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] ChatRequestPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[7];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatRequest),
			Converter = null,
			Getter = (object obj) => ((ChatRequest)obj).message,
			Setter = delegate(object obj, string? value)
			{
				((ChatRequest)obj).message = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "message",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatRequest).GetProperty("message", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatRequest),
			Converter = null,
			Getter = (object obj) => ((ChatRequest)obj).modelIndex,
			Setter = delegate(object obj, int value)
			{
				((ChatRequest)obj).modelIndex = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "modelIndex",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatRequest).GetProperty("modelIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatRequest),
			Converter = null,
			Getter = (object obj) => ((ChatRequest)obj).sop,
			Setter = delegate(object obj, string? value)
			{
				((ChatRequest)obj).sop = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "sop",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatRequest).GetProperty("sop", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatRequest),
			Converter = null,
			Getter = (object obj) => ((ChatRequest)obj).caller,
			Setter = delegate(object obj, string? value)
			{
				((ChatRequest)obj).caller = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "caller",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatRequest).GetProperty("caller", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatRequest),
			Converter = null,
			Getter = (object obj) => ((ChatRequest)obj).taskId,
			Setter = delegate(object obj, string? value)
			{
				((ChatRequest)obj).taskId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "taskId",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatRequest).GetProperty("taskId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatRequest),
			Converter = null,
			Getter = (object obj) => ((ChatRequest)obj).lineageContext,
			Setter = delegate(object obj, string? value)
			{
				((ChatRequest)obj).lineageContext = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "lineageContext",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatRequest).GetProperty("lineageContext", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<JsonElement?> propertyInfo7 = new JsonPropertyInfoValues<JsonElement?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatRequest),
			Converter = null,
			Getter = (object obj) => ((ChatRequest)obj).snapshotAuditPayload,
			Setter = delegate(object obj, JsonElement? value)
			{
				((ChatRequest)obj).snapshotAuditPayload = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "snapshotAuditPayload",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatRequest).GetProperty("snapshotAuditPayload", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(JsonElement?), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		return array;
	}

	private void ChatRequestSerializeHandler(Utf8JsonWriter writer, ChatRequest? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_message, value.message);
		writer.WriteNumber(PropName_modelIndex, value.modelIndex);
		writer.WriteString(PropName_sop, value.sop);
		writer.WriteString(PropName_caller, value.caller);
		writer.WriteString(PropName_taskId, value.taskId);
		writer.WriteString(PropName_lineageContext, value.lineageContext);
		writer.WritePropertyName(PropName_snapshotAuditPayload);
		JsonSerializer.Serialize(writer, value.snapshotAuditPayload, NullableJsonElement);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<ChatResponse> Create_ChatResponse(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatResponse> jsonTypeInfo))
		{
			JsonObjectInfoValues<ChatResponse> objectInfo = new JsonObjectInfoValues<ChatResponse>
			{
				ObjectCreator = () => new ChatResponse(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => ChatResponsePropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(ChatResponse).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = ChatResponseSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] ChatResponsePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatResponse),
			Converter = null,
			Getter = (object obj) => ((ChatResponse)obj).type,
			Setter = delegate(object obj, string? value)
			{
				((ChatResponse)obj).type = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "type",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatResponse).GetProperty("type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ChatResponse),
			Converter = null,
			Getter = (object obj) => ((ChatResponse)obj).content,
			Setter = delegate(object obj, string? value)
			{
				((ChatResponse)obj).content = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "content",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(ChatResponse).GetProperty("content", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		return array;
	}

	private void ChatResponseSerializeHandler(Utf8JsonWriter writer, ChatResponse? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_type, value.type);
		writer.WriteString(PropName_content, value.content);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<CompanyGoal> Create_CompanyGoal(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<CompanyGoal> jsonTypeInfo))
		{
			JsonObjectInfoValues<CompanyGoal> objectInfo = new JsonObjectInfoValues<CompanyGoal>
			{
				ObjectCreator = () => new CompanyGoal(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => CompanyGoalPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(CompanyGoal).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = CompanyGoalSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] CompanyGoalPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[4];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CompanyGoal),
			Converter = null,
			Getter = (object obj) => ((CompanyGoal)obj).Id,
			Setter = delegate(object obj, string? value)
			{
				((CompanyGoal)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(CompanyGoal).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CompanyGoal),
			Converter = null,
			Getter = (object obj) => ((CompanyGoal)obj).Title,
			Setter = delegate(object obj, string? value)
			{
				((CompanyGoal)obj).Title = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Title",
			JsonPropertyName = "title",
			AttributeProviderFactory = () => typeof(CompanyGoal).GetProperty("Title", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CompanyGoal),
			Converter = null,
			Getter = (object obj) => ((CompanyGoal)obj).Description,
			Setter = delegate(object obj, string? value)
			{
				((CompanyGoal)obj).Description = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Description",
			JsonPropertyName = "description",
			AttributeProviderFactory = () => typeof(CompanyGoal).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CompanyGoal),
			Converter = null,
			Getter = (object obj) => ((CompanyGoal)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((CompanyGoal)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(CompanyGoal).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		return array;
	}

	private void CompanyGoalSerializeHandler(Utf8JsonWriter writer, CompanyGoal? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_id, value.Id);
		writer.WriteString(PropName_title, value.Title);
		writer.WriteString(PropName_description, value.Description);
		writer.WriteString(PropName_status, value.Status);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<CompanySetupResult> Create_CompanySetupResult(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<CompanySetupResult> jsonTypeInfo))
		{
			JsonObjectInfoValues<CompanySetupResult> objectInfo = new JsonObjectInfoValues<CompanySetupResult>
			{
				ObjectCreator = () => new CompanySetupResult(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => CompanySetupResultPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(CompanySetupResult).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = CompanySetupResultSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] CompanySetupResultPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CompanySetupResult),
			Converter = null,
			Getter = (object obj) => ((CompanySetupResult)obj).Profile,
			Setter = delegate(object obj, string? value)
			{
				((CompanySetupResult)obj).Profile = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Profile",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(CompanySetupResult).GetProperty("Profile", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<List<NodeInfoTemplate>> propertyInfo2 = new JsonPropertyInfoValues<List<NodeInfoTemplate>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CompanySetupResult),
			Converter = null,
			Getter = (object obj) => ((CompanySetupResult)obj).Employees,
			Setter = delegate(object obj, List<NodeInfoTemplate>? value)
			{
				((CompanySetupResult)obj).Employees = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Employees",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(CompanySetupResult).GetProperty("Employees", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<NodeInfoTemplate>), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		return array;
	}

	private void CompanySetupResultSerializeHandler(Utf8JsonWriter writer, CompanySetupResult? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_Profile, value.Profile);
		writer.WritePropertyName(PropName_Employees);
		ListNodeInfoTemplateSerializeHandler(writer, value.Employees);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<CreateCompanyReq> Create_CreateCompanyReq(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<CreateCompanyReq> jsonTypeInfo))
		{
			JsonObjectInfoValues<CreateCompanyReq> objectInfo = new JsonObjectInfoValues<CreateCompanyReq>
			{
				ObjectCreator = () => new CreateCompanyReq(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => CreateCompanyReqPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(CreateCompanyReq).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = CreateCompanyReqSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] CreateCompanyReqPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[2];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CreateCompanyReq),
			Converter = null,
			Getter = (object obj) => ((CreateCompanyReq)obj).Description,
			Setter = delegate(object obj, string? value)
			{
				((CreateCompanyReq)obj).Description = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Description",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(CreateCompanyReq).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(CreateCompanyReq),
			Converter = null,
			Getter = (object obj) => ((CreateCompanyReq)obj).MasterNodeUrl,
			Setter = delegate(object obj, string? value)
			{
				((CreateCompanyReq)obj).MasterNodeUrl = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "MasterNodeUrl",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(CreateCompanyReq).GetProperty("MasterNodeUrl", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		return array;
	}

	private void CreateCompanyReqSerializeHandler(Utf8JsonWriter writer, CreateCompanyReq? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_Description, value.Description);
		writer.WriteString(PropName_MasterNodeUrl, value.MasterNodeUrl);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<LocalNodeAdminConfigPayload> Create_LocalNodeAdminConfigPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<LocalNodeAdminConfigPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<LocalNodeAdminConfigPayload> objectInfo = new JsonObjectInfoValues<LocalNodeAdminConfigPayload>
			{
				ObjectCreator = () => new LocalNodeAdminConfigPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => LocalNodeAdminConfigPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(LocalNodeAdminConfigPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = LocalNodeAdminConfigPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] LocalNodeAdminConfigPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[6];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminConfigPayload)obj).BaseUrl,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminConfigPayload)obj).BaseUrl = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BaseUrl",
			JsonPropertyName = "baseUrl",
			AttributeProviderFactory = () => typeof(LocalNodeAdminConfigPayload).GetProperty("BaseUrl", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminConfigPayload)obj).ApiKey,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminConfigPayload)obj).ApiKey = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ApiKey",
			JsonPropertyName = "apiKey",
			AttributeProviderFactory = () => typeof(LocalNodeAdminConfigPayload).GetProperty("ApiKey", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminConfigPayload)obj).Port,
			Setter = delegate(object obj, int value)
			{
				((LocalNodeAdminConfigPayload)obj).Port = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Port",
			JsonPropertyName = "port",
			AttributeProviderFactory = () => typeof(LocalNodeAdminConfigPayload).GetProperty("Port", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<List<ModelEndpointConfig>> propertyInfo4 = new JsonPropertyInfoValues<List<ModelEndpointConfig>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminConfigPayload)obj).Models,
			Setter = delegate(object obj, List<ModelEndpointConfig>? value)
			{
				((LocalNodeAdminConfigPayload)obj).Models = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Models",
			JsonPropertyName = "models",
			AttributeProviderFactory = () => typeof(LocalNodeAdminConfigPayload).GetProperty("Models", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<ModelEndpointConfig>), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<Dictionary<string, NodeInfo>> propertyInfo5 = new JsonPropertyInfoValues<Dictionary<string, NodeInfo>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminConfigPayload)obj).PeerNodes,
			Setter = delegate(object obj, Dictionary<string, NodeInfo>? value)
			{
				((LocalNodeAdminConfigPayload)obj).PeerNodes = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "PeerNodes",
			JsonPropertyName = "peerNodes",
			AttributeProviderFactory = () => typeof(LocalNodeAdminConfigPayload).GetProperty("PeerNodes", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, NodeInfo>), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminConfigPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminConfigPayload)obj).ConfigPath,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminConfigPayload)obj).ConfigPath = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ConfigPath",
			JsonPropertyName = "configPath",
			AttributeProviderFactory = () => typeof(LocalNodeAdminConfigPayload).GetProperty("ConfigPath", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		return array;
	}

	private void LocalNodeAdminConfigPayloadSerializeHandler(Utf8JsonWriter writer, LocalNodeAdminConfigPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_baseUrl, value.BaseUrl);
		writer.WriteString(PropName_apiKey, value.ApiKey);
		writer.WriteNumber(PropName_port, value.Port);
		writer.WritePropertyName(PropName_models);
		ListModelEndpointConfigSerializeHandler(writer, value.Models);
		writer.WritePropertyName(PropName_peerNodes);
		DictionaryStringNodeInfoSerializeHandler(writer, value.PeerNodes);
		writer.WriteString(PropName_configPath, value.ConfigPath);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<LocalNodeAdminDisabledModel> Create_LocalNodeAdminDisabledModel(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<LocalNodeAdminDisabledModel> jsonTypeInfo))
		{
			JsonObjectInfoValues<LocalNodeAdminDisabledModel> objectInfo = new JsonObjectInfoValues<LocalNodeAdminDisabledModel>
			{
				ObjectCreator = () => new LocalNodeAdminDisabledModel(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => LocalNodeAdminDisabledModelPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(LocalNodeAdminDisabledModel).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = LocalNodeAdminDisabledModelSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] LocalNodeAdminDisabledModelPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisabledModel),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisabledModel)obj).Provider,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminDisabledModel)obj).Provider = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Provider",
			JsonPropertyName = "provider",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisabledModel).GetProperty("Provider", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisabledModel),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisabledModel)obj).Model,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminDisabledModel)obj).Model = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Model",
			JsonPropertyName = "model",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisabledModel).GetProperty("Model", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisabledModel),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisabledModel)obj).Version,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminDisabledModel)obj).Version = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Version",
			JsonPropertyName = "version",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisabledModel).GetProperty("Version", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisabledModel),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisabledModel)obj).EndpointId,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminDisabledModel)obj).EndpointId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EndpointId",
			JsonPropertyName = "endpointId",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisabledModel).GetProperty("EndpointId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisabledModel),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisabledModel)obj).Reason,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminDisabledModel)obj).Reason = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Reason",
			JsonPropertyName = "reason",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisabledModel).GetProperty("Reason", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		return array;
	}

	private void LocalNodeAdminDisabledModelSerializeHandler(Utf8JsonWriter writer, LocalNodeAdminDisabledModel? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_provider, value.Provider);
		writer.WriteString(PropName_model, value.Model);
		writer.WriteString(PropName_version, value.Version);
		writer.WriteString(PropName_endpointId, value.EndpointId);
		writer.WriteString(PropName_reason, value.Reason);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<LocalNodeAdminDisableResult> Create_LocalNodeAdminDisableResult(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<LocalNodeAdminDisableResult> jsonTypeInfo))
		{
			JsonObjectInfoValues<LocalNodeAdminDisableResult> objectInfo = new JsonObjectInfoValues<LocalNodeAdminDisableResult>
			{
				ObjectCreator = () => new LocalNodeAdminDisableResult(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => LocalNodeAdminDisableResultPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(LocalNodeAdminDisableResult).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = LocalNodeAdminDisableResultSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] LocalNodeAdminDisableResultPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisableResult),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisableResult)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminDisableResult)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisableResult).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisableResult),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisableResult)obj).CheckedCount,
			Setter = delegate(object obj, int value)
			{
				((LocalNodeAdminDisableResult)obj).CheckedCount = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CheckedCount",
			JsonPropertyName = "checkedCount",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisableResult).GetProperty("CheckedCount", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisableResult),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisableResult)obj).DisabledCount,
			Setter = delegate(object obj, int value)
			{
				((LocalNodeAdminDisableResult)obj).DisabledCount = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DisabledCount",
			JsonPropertyName = "disabledCount",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisableResult).GetProperty("DisabledCount", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<List<LocalNodeAdminDisabledModel>> propertyInfo4 = new JsonPropertyInfoValues<List<LocalNodeAdminDisabledModel>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisableResult),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisableResult)obj).DisabledModels,
			Setter = delegate(object obj, List<LocalNodeAdminDisabledModel>? value)
			{
				((LocalNodeAdminDisableResult)obj).DisabledModels = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DisabledModels",
			JsonPropertyName = "disabledModels",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisableResult).GetProperty("DisabledModels", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<LocalNodeAdminDisabledModel>), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeAdminDisableResult),
			Converter = null,
			Getter = (object obj) => ((LocalNodeAdminDisableResult)obj).Summary,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeAdminDisableResult)obj).Summary = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Summary",
			JsonPropertyName = "summary",
			AttributeProviderFactory = () => typeof(LocalNodeAdminDisableResult).GetProperty("Summary", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		return array;
	}

	private void LocalNodeAdminDisableResultSerializeHandler(Utf8JsonWriter writer, LocalNodeAdminDisableResult? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_status, value.Status);
		writer.WriteNumber(PropName_checkedCount, value.CheckedCount);
		writer.WriteNumber(PropName_disabledCount, value.DisabledCount);
		writer.WritePropertyName(PropName_disabledModels);
		ListLocalNodeAdminDisabledModelSerializeHandler(writer, value.DisabledModels);
		writer.WriteString(PropName_summary, value.Summary);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<LocalNodeModelPayload> Create_LocalNodeModelPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<LocalNodeModelPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<LocalNodeModelPayload> objectInfo = new JsonObjectInfoValues<LocalNodeModelPayload>
			{
				ObjectCreator = () => new LocalNodeModelPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => LocalNodeModelPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = LocalNodeModelPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] LocalNodeModelPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[7];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeModelPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeModelPayload)obj).Provider,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeModelPayload)obj).Provider = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Provider",
			JsonPropertyName = "Provider",
			AttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetProperty("Provider", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeModelPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeModelPayload)obj).Name,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeModelPayload)obj).Name = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Name",
			JsonPropertyName = "Name",
			AttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeModelPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeModelPayload)obj).Version,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeModelPayload)obj).Version = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Version",
			JsonPropertyName = "Version",
			AttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetProperty("Version", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeModelPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeModelPayload)obj).BaseUrl,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeModelPayload)obj).BaseUrl = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BaseUrl",
			JsonPropertyName = "BaseUrl",
			AttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetProperty("BaseUrl", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeModelPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeModelPayload)obj).ApiKey,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeModelPayload)obj).ApiKey = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ApiKey",
			JsonPropertyName = "ApiKey",
			AttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetProperty("ApiKey", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo6 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeModelPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeModelPayload)obj).Enabled,
			Setter = delegate(object obj, bool value)
			{
				((LocalNodeModelPayload)obj).Enabled = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Enabled",
			JsonPropertyName = "Enabled",
			AttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetProperty("Enabled", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(LocalNodeModelPayload),
			Converter = null,
			Getter = (object obj) => ((LocalNodeModelPayload)obj).EndpointId,
			Setter = delegate(object obj, string? value)
			{
				((LocalNodeModelPayload)obj).EndpointId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EndpointId",
			JsonPropertyName = "EndpointId",
			AttributeProviderFactory = () => typeof(LocalNodeModelPayload).GetProperty("EndpointId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		return array;
	}

	private void LocalNodeModelPayloadSerializeHandler(Utf8JsonWriter writer, LocalNodeModelPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_Provider, value.Provider);
		writer.WriteString(PropName_Name, value.Name);
		writer.WriteString(PropName_Version, value.Version);
		writer.WriteString(PropName_BaseUrl, value.BaseUrl);
		writer.WriteString(PropName_ApiKey, value.ApiKey);
		writer.WriteBoolean(PropName_Enabled, value.Enabled);
		writer.WriteString(PropName_EndpointId, value.EndpointId);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<ModelEndpointConfig> Create_ModelEndpointConfig(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ModelEndpointConfig> jsonTypeInfo))
		{
			JsonObjectInfoValues<ModelEndpointConfig> objectInfo = new JsonObjectInfoValues<ModelEndpointConfig>
			{
				ObjectCreator = () => new ModelEndpointConfig(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => ModelEndpointConfigPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(ModelEndpointConfig).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = ModelEndpointConfigSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] ModelEndpointConfigPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[9];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).Id,
			Setter = delegate(object obj, string? value)
			{
				((ModelEndpointConfig)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).Provider,
			Setter = delegate(object obj, string? value)
			{
				((ModelEndpointConfig)obj).Provider = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Provider",
			JsonPropertyName = "provider",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("Provider", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).Name,
			Setter = delegate(object obj, string? value)
			{
				((ModelEndpointConfig)obj).Name = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Name",
			JsonPropertyName = "name",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).Version,
			Setter = delegate(object obj, string? value)
			{
				((ModelEndpointConfig)obj).Version = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Version",
			JsonPropertyName = "version",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("Version", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).BaseUrl,
			Setter = delegate(object obj, string? value)
			{
				((ModelEndpointConfig)obj).BaseUrl = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BaseUrl",
			JsonPropertyName = "baseUrl",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("BaseUrl", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).ApiKey,
			Setter = delegate(object obj, string? value)
			{
				((ModelEndpointConfig)obj).ApiKey = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ApiKey",
			JsonPropertyName = "apiKey",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("ApiKey", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo7 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).Enabled,
			Setter = delegate(object obj, bool value)
			{
				((ModelEndpointConfig)obj).Enabled = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Enabled",
			JsonPropertyName = "enabled",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("Enabled", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).EndpointId,
			Setter = delegate(object obj, string? value)
			{
				((ModelEndpointConfig)obj).EndpointId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "EndpointId",
			JsonPropertyName = "endpointId",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("EndpointId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		array[7].IsGetNullable = false;
		array[7].IsSetNullable = false;
		JsonPropertyInfoValues<int> propertyInfo9 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ModelEndpointConfig),
			Converter = null,
			Getter = (object obj) => ((ModelEndpointConfig)obj).SortOrder,
			Setter = delegate(object obj, int value)
			{
				((ModelEndpointConfig)obj).SortOrder = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "SortOrder",
			JsonPropertyName = "sortOrder",
			AttributeProviderFactory = () => typeof(ModelEndpointConfig).GetProperty("SortOrder", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		return array;
	}

	private void ModelEndpointConfigSerializeHandler(Utf8JsonWriter writer, ModelEndpointConfig? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_id, value.Id);
		writer.WriteString(PropName_provider, value.Provider);
		writer.WriteString(PropName_name, value.Name);
		writer.WriteString(PropName_version, value.Version);
		writer.WriteString(PropName_baseUrl, value.BaseUrl);
		writer.WriteString(PropName_apiKey, value.ApiKey);
		writer.WriteBoolean(PropName_enabled, value.Enabled);
		writer.WriteString(PropName_endpointId, value.EndpointId);
		writer.WriteNumber(PropName_sortOrder, value.SortOrder);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<NodeDiagnosis> Create_NodeDiagnosis(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<NodeDiagnosis> jsonTypeInfo))
		{
			JsonObjectInfoValues<NodeDiagnosis> objectInfo = new JsonObjectInfoValues<NodeDiagnosis>
			{
				ObjectCreator = () => new NodeDiagnosis(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => NodeDiagnosisPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(NodeDiagnosis).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = NodeDiagnosisSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] NodeDiagnosisPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[11];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).Name,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).Name = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Name",
			JsonPropertyName = "name",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).Url,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).Url = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Url",
			JsonPropertyName = "url",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("Url", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "adapterType",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo4 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).Online,
			Setter = delegate(object obj, bool value)
			{
				((NodeDiagnosis)obj).Online = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Online",
			JsonPropertyName = "online",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("Online", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<bool> propertyInfo5 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).ConfigOk,
			Setter = delegate(object obj, bool value)
			{
				((NodeDiagnosis)obj).ConfigOk = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ConfigOk",
			JsonPropertyName = "configOk",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("ConfigOk", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<bool> propertyInfo6 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).StatusOk,
			Setter = delegate(object obj, bool value)
			{
				((NodeDiagnosis)obj).StatusOk = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "StatusOk",
			JsonPropertyName = "statusOk",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("StatusOk", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).Reason,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).Reason = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Reason",
			JsonPropertyName = "reason",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("Reason", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).Suggestion,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).Suggestion = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Suggestion",
			JsonPropertyName = "suggestion",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("Suggestion", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		array[7].IsGetNullable = false;
		array[7].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).LastCheckedAt,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).LastCheckedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastCheckedAt",
			JsonPropertyName = "lastCheckedAt",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("LastCheckedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		array[8].IsGetNullable = false;
		array[8].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).LogHint,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).LogHint = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LogHint",
			JsonPropertyName = "logHint",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("LogHint", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		array[9].IsGetNullable = false;
		array[9].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo11 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeDiagnosis),
			Converter = null,
			Getter = (object obj) => ((NodeDiagnosis)obj).RestartHint,
			Setter = delegate(object obj, string? value)
			{
				((NodeDiagnosis)obj).RestartHint = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RestartHint",
			JsonPropertyName = "restartHint",
			AttributeProviderFactory = () => typeof(NodeDiagnosis).GetProperty("RestartHint", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		array[10].IsGetNullable = false;
		array[10].IsSetNullable = false;
		return array;
	}

	private void NodeDiagnosisSerializeHandler(Utf8JsonWriter writer, NodeDiagnosis? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_name, value.Name);
		writer.WriteString(PropName_url, value.Url);
		writer.WriteString(PropName_adapterType, value.AdapterType);
		writer.WriteBoolean(PropName_online, value.Online);
		writer.WriteBoolean(PropName_configOk, value.ConfigOk);
		writer.WriteBoolean(PropName_statusOk, value.StatusOk);
		writer.WriteString(PropName_reason, value.Reason);
		writer.WriteString(PropName_suggestion, value.Suggestion);
		writer.WriteString(PropName_lastCheckedAt, value.LastCheckedAt);
		writer.WriteString(PropName_logHint, value.LogHint);
		writer.WriteString(PropName_restartHint, value.RestartHint);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<NodeInfo> Create_NodeInfo(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<NodeInfo> jsonTypeInfo))
		{
			JsonObjectInfoValues<NodeInfo> objectInfo = new JsonObjectInfoValues<NodeInfo>
			{
				ObjectCreator = () => new NodeInfo(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => NodeInfoPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(NodeInfo).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = NodeInfoSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] NodeInfoPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[14];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).Name,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfo)obj).Name = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Name",
			JsonPropertyName = "Name",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).Url,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfo)obj).Url = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Url",
			JsonPropertyName = "Url",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("Url", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).Role,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfo)obj).Role = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Role",
			JsonPropertyName = "Role",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("Role", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).Description,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfo)obj).Description = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Description",
			JsonPropertyName = "Description",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).Resume,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfo)obj).Resume = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Resume",
			JsonPropertyName = "Resume",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("Resume", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<int> propertyInfo6 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).ModelIndex,
			Setter = delegate(object obj, int value)
			{
				((NodeInfo)obj).ModelIndex = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ModelIndex",
			JsonPropertyName = "ModelIndex",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("ModelIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).AdapterType,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfo)obj).AdapterType = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterType",
			JsonPropertyName = "AdapterType",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("AdapterType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<Dictionary<string, JsonElement>> propertyInfo8 = new JsonPropertyInfoValues<Dictionary<string, JsonElement>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).AdapterConfig,
			Setter = delegate(object obj, Dictionary<string, JsonElement>? value)
			{
				((NodeInfo)obj).AdapterConfig = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AdapterConfig",
			JsonPropertyName = "AdapterConfig",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("AdapterConfig", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, JsonElement>), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<List<string>> propertyInfo9 = new JsonPropertyInfoValues<List<string>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).Capabilities,
			Setter = delegate(object obj, List<string>? value)
			{
				((NodeInfo)obj).Capabilities = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Capabilities",
			JsonPropertyName = "Capabilities",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("Capabilities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).ReportsTo,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfo)obj).ReportsTo = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ReportsTo",
			JsonPropertyName = "ReportsTo",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("ReportsTo", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		JsonPropertyInfoValues<decimal?> propertyInfo11 = new JsonPropertyInfoValues<decimal?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).BudgetMonthly,
			Setter = delegate(object obj, decimal? value)
			{
				((NodeInfo)obj).BudgetMonthly = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BudgetMonthly",
			JsonPropertyName = "BudgetMonthly",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("BudgetMonthly", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(decimal?), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		JsonPropertyInfoValues<decimal?> propertyInfo12 = new JsonPropertyInfoValues<decimal?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).BudgetUsed,
			Setter = delegate(object obj, decimal? value)
			{
				((NodeInfo)obj).BudgetUsed = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BudgetUsed",
			JsonPropertyName = "BudgetUsed",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("BudgetUsed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(decimal?), Array.Empty<Type>(), null)
		};
		array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
		JsonPropertyInfoValues<decimal?> propertyInfo13 = new JsonPropertyInfoValues<decimal?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).BudgetSoftLimitRatio,
			Setter = delegate(object obj, decimal? value)
			{
				((NodeInfo)obj).BudgetSoftLimitRatio = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BudgetSoftLimitRatio",
			JsonPropertyName = "BudgetSoftLimitRatio",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("BudgetSoftLimitRatio", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(decimal?), Array.Empty<Type>(), null)
		};
		array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
		JsonPropertyInfoValues<decimal?> propertyInfo14 = new JsonPropertyInfoValues<decimal?>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfo),
			Converter = null,
			Getter = (object obj) => ((NodeInfo)obj).BudgetHardLimitRatio,
			Setter = delegate(object obj, decimal? value)
			{
				((NodeInfo)obj).BudgetHardLimitRatio = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BudgetHardLimitRatio",
			JsonPropertyName = "BudgetHardLimitRatio",
			AttributeProviderFactory = () => typeof(NodeInfo).GetProperty("BudgetHardLimitRatio", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(decimal?), Array.Empty<Type>(), null)
		};
		array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
		return array;
	}

	private void NodeInfoSerializeHandler(Utf8JsonWriter writer, NodeInfo? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_Name, value.Name);
		writer.WriteString(PropName_Url, value.Url);
		writer.WriteString(PropName_Role, value.Role);
		writer.WriteString(PropName_Description, value.Description);
		writer.WriteString(PropName_Resume, value.Resume);
		writer.WriteNumber(PropName_ModelIndex, value.ModelIndex);
		writer.WriteString(PropName_AdapterType, value.AdapterType);
		writer.WritePropertyName(PropName_AdapterConfig);
		DictionaryStringJsonElementSerializeHandler(writer, value.AdapterConfig);
		writer.WritePropertyName(PropName_Capabilities);
		ListStringSerializeHandler(writer, value.Capabilities);
		writer.WriteString(PropName_ReportsTo, value.ReportsTo);
		writer.WritePropertyName(PropName_BudgetMonthly);
		JsonSerializer.Serialize(writer, value.BudgetMonthly, NullableDecimal);
		writer.WritePropertyName(PropName_BudgetUsed);
		JsonSerializer.Serialize(writer, value.BudgetUsed, NullableDecimal);
		writer.WritePropertyName(PropName_BudgetSoftLimitRatio);
		JsonSerializer.Serialize(writer, value.BudgetSoftLimitRatio, NullableDecimal);
		writer.WritePropertyName(PropName_BudgetHardLimitRatio);
		JsonSerializer.Serialize(writer, value.BudgetHardLimitRatio, NullableDecimal);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<NodeInfoTemplate> Create_NodeInfoTemplate(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<NodeInfoTemplate> jsonTypeInfo))
		{
			JsonObjectInfoValues<NodeInfoTemplate> objectInfo = new JsonObjectInfoValues<NodeInfoTemplate>
			{
				ObjectCreator = () => new NodeInfoTemplate(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => NodeInfoTemplatePropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(NodeInfoTemplate).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = NodeInfoTemplateSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] NodeInfoTemplatePropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[6];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfoTemplate),
			Converter = null,
			Getter = (object obj) => ((NodeInfoTemplate)obj).name,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfoTemplate)obj).name = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "name",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(NodeInfoTemplate).GetProperty("name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfoTemplate),
			Converter = null,
			Getter = (object obj) => ((NodeInfoTemplate)obj).Role,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfoTemplate)obj).Role = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Role",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(NodeInfoTemplate).GetProperty("Role", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfoTemplate),
			Converter = null,
			Getter = (object obj) => ((NodeInfoTemplate)obj).Url,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfoTemplate)obj).Url = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Url",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(NodeInfoTemplate).GetProperty("Url", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfoTemplate),
			Converter = null,
			Getter = (object obj) => ((NodeInfoTemplate)obj).Description,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfoTemplate)obj).Description = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Description",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(NodeInfoTemplate).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfoTemplate),
			Converter = null,
			Getter = (object obj) => ((NodeInfoTemplate)obj).Resume,
			Setter = delegate(object obj, string? value)
			{
				((NodeInfoTemplate)obj).Resume = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Resume",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(NodeInfoTemplate).GetProperty("Resume", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<int> propertyInfo6 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(NodeInfoTemplate),
			Converter = null,
			Getter = (object obj) => ((NodeInfoTemplate)obj).ModelIndex,
			Setter = delegate(object obj, int value)
			{
				((NodeInfoTemplate)obj).ModelIndex = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ModelIndex",
			JsonPropertyName = null,
			AttributeProviderFactory = () => typeof(NodeInfoTemplate).GetProperty("ModelIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		return array;
	}

	private void NodeInfoTemplateSerializeHandler(Utf8JsonWriter writer, NodeInfoTemplate? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_name, value.name);
		writer.WriteString(PropName_Role, value.Role);
		writer.WriteString(PropName_Url, value.Url);
		writer.WriteString(PropName_Description, value.Description);
		writer.WriteString(PropName_Resume, value.Resume);
		writer.WriteNumber(PropName_ModelIndex, value.ModelIndex);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<OrgNodePayload> Create_OrgNodePayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<OrgNodePayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<OrgNodePayload> objectInfo = new JsonObjectInfoValues<OrgNodePayload>
			{
				ObjectCreator = () => new OrgNodePayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => OrgNodePayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(OrgNodePayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = OrgNodePayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] OrgNodePayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OrgNodePayload),
			Converter = null,
			Getter = (object obj) => ((OrgNodePayload)obj).Name,
			Setter = delegate(object obj, string? value)
			{
				((OrgNodePayload)obj).Name = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Name",
			JsonPropertyName = "name",
			AttributeProviderFactory = () => typeof(OrgNodePayload).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OrgNodePayload),
			Converter = null,
			Getter = (object obj) => ((OrgNodePayload)obj).Role,
			Setter = delegate(object obj, string? value)
			{
				((OrgNodePayload)obj).Role = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Role",
			JsonPropertyName = "role",
			AttributeProviderFactory = () => typeof(OrgNodePayload).GetProperty("Role", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OrgNodePayload),
			Converter = null,
			Getter = (object obj) => ((OrgNodePayload)obj).ReportsTo,
			Setter = delegate(object obj, string? value)
			{
				((OrgNodePayload)obj).ReportsTo = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ReportsTo",
			JsonPropertyName = "reportsTo",
			AttributeProviderFactory = () => typeof(OrgNodePayload).GetProperty("ReportsTo", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<List<string>> propertyInfo4 = new JsonPropertyInfoValues<List<string>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OrgNodePayload),
			Converter = null,
			Getter = (object obj) => ((OrgNodePayload)obj).DirectReports,
			Setter = delegate(object obj, List<string>? value)
			{
				((OrgNodePayload)obj).DirectReports = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DirectReports",
			JsonPropertyName = "directReports",
			AttributeProviderFactory = () => typeof(OrgNodePayload).GetProperty("DirectReports", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<List<string>> propertyInfo5 = new JsonPropertyInfoValues<List<string>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(OrgNodePayload),
			Converter = null,
			Getter = (object obj) => ((OrgNodePayload)obj).ChainOfCommand,
			Setter = delegate(object obj, List<string>? value)
			{
				((OrgNodePayload)obj).ChainOfCommand = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ChainOfCommand",
			JsonPropertyName = "chainOfCommand",
			AttributeProviderFactory = () => typeof(OrgNodePayload).GetProperty("ChainOfCommand", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		return array;
	}

	private void OrgNodePayloadSerializeHandler(Utf8JsonWriter writer, OrgNodePayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_name, value.Name);
		writer.WriteString(PropName_role, value.Role);
		writer.WriteString(PropName_reportsTo, value.ReportsTo);
		writer.WritePropertyName(PropName_directReports);
		ListStringSerializeHandler(writer, value.DirectReports);
		writer.WritePropertyName(PropName_chainOfCommand);
		ListStringSerializeHandler(writer, value.ChainOfCommand);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<ProjectBoard> Create_ProjectBoard(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ProjectBoard> jsonTypeInfo))
		{
			JsonObjectInfoValues<ProjectBoard> objectInfo = new JsonObjectInfoValues<ProjectBoard>
			{
				ObjectCreator = () => new ProjectBoard(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => ProjectBoardPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(ProjectBoard).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = ProjectBoardSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] ProjectBoardPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[5];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectBoard),
			Converter = null,
			Getter = (object obj) => ((ProjectBoard)obj).ProjectName,
			Setter = delegate(object obj, string? value)
			{
				((ProjectBoard)obj).ProjectName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ProjectName",
			JsonPropertyName = "project_name",
			AttributeProviderFactory = () => typeof(ProjectBoard).GetProperty("ProjectName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		JsonPropertyInfoValues<List<ProjectTask>> propertyInfo2 = new JsonPropertyInfoValues<List<ProjectTask>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectBoard),
			Converter = null,
			Getter = (object obj) => ((ProjectBoard)obj).Tasks,
			Setter = delegate(object obj, List<ProjectTask>? value)
			{
				((ProjectBoard)obj).Tasks = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Tasks",
			JsonPropertyName = "tasks",
			AttributeProviderFactory = () => typeof(ProjectBoard).GetProperty("Tasks", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<ProjectTask>), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectBoard),
			Converter = null,
			Getter = (object obj) => ((ProjectBoard)obj).GoalId,
			Setter = delegate(object obj, string? value)
			{
				((ProjectBoard)obj).GoalId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "GoalId",
			JsonPropertyName = "goal_id",
			AttributeProviderFactory = () => typeof(ProjectBoard).GetProperty("GoalId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectBoard),
			Converter = null,
			Getter = (object obj) => ((ProjectBoard)obj).ProjectGoal,
			Setter = delegate(object obj, string? value)
			{
				((ProjectBoard)obj).ProjectGoal = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ProjectGoal",
			JsonPropertyName = "project_goal",
			AttributeProviderFactory = () => typeof(ProjectBoard).GetProperty("ProjectGoal", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectBoard),
			Converter = null,
			Getter = (object obj) => ((ProjectBoard)obj).ContextSummary,
			Setter = delegate(object obj, string? value)
			{
				((ProjectBoard)obj).ContextSummary = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ContextSummary",
			JsonPropertyName = "context_summary",
			AttributeProviderFactory = () => typeof(ProjectBoard).GetProperty("ContextSummary", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		return array;
	}

	private void ProjectBoardSerializeHandler(Utf8JsonWriter writer, ProjectBoard? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_project_name, value.ProjectName);
		writer.WritePropertyName(PropName_tasks);
		ListProjectTaskSerializeHandler(writer, value.Tasks);
		writer.WriteString(PropName_goal_id, value.GoalId);
		writer.WriteString(PropName_project_goal, value.ProjectGoal);
		writer.WriteString(PropName_context_summary, value.ContextSummary);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<ProjectTask> Create_ProjectTask(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ProjectTask> jsonTypeInfo))
		{
			JsonObjectInfoValues<ProjectTask> objectInfo = new JsonObjectInfoValues<ProjectTask>
			{
				ObjectCreator = () => new ProjectTask(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => ProjectTaskPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(ProjectTask).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = ProjectTaskSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] ProjectTaskPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[19];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Id,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Title,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Title = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Title",
			JsonPropertyName = "title",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Title", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Assignee,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Assignee = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Assignee",
			JsonPropertyName = "assignee",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Assignee", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).UpdateTime,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).UpdateTime = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "UpdateTime",
			JsonPropertyName = "update_time",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("UpdateTime", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Result,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Result = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Result",
			JsonPropertyName = "result",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Result", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Priority,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Priority = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Priority",
			JsonPropertyName = "priority",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Priority", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).ParentId,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).ParentId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ParentId",
			JsonPropertyName = "parent_id",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("ParentId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).GoalId,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).GoalId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "GoalId",
			JsonPropertyName = "goal_id",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("GoalId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).CheckedOutBy,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).CheckedOutBy = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CheckedOutBy",
			JsonPropertyName = "checked_out_by",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("CheckedOutBy", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		JsonPropertyInfoValues<string> propertyInfo11 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).CheckedOutAt,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).CheckedOutAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CheckedOutAt",
			JsonPropertyName = "checked_out_at",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("CheckedOutAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).BlockedReason,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).BlockedReason = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "BlockedReason",
			JsonPropertyName = "blocked_reason",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("BlockedReason", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
		JsonPropertyInfoValues<bool> propertyInfo13 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).ReviewRequired,
			Setter = delegate(object obj, bool value)
			{
				((ProjectTask)obj).ReviewRequired = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ReviewRequired",
			JsonPropertyName = "review_required",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("ReviewRequired", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
		JsonPropertyInfoValues<List<TaskComment>> propertyInfo14 = new JsonPropertyInfoValues<List<TaskComment>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Comments,
			Setter = delegate(object obj, List<TaskComment>? value)
			{
				((ProjectTask)obj).Comments = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Comments",
			JsonPropertyName = "comments",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Comments", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<TaskComment>), Array.Empty<Type>(), null)
		};
		array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
		array[13].IsGetNullable = false;
		array[13].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo15 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).ContextSummary,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).ContextSummary = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ContextSummary",
			JsonPropertyName = "context_summary",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("ContextSummary", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
		JsonPropertyInfoValues<string> propertyInfo16 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Phase,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Phase = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Phase",
			JsonPropertyName = "phase",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Phase", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[15] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo16);
		JsonPropertyInfoValues<List<string>> propertyInfo17 = new JsonPropertyInfoValues<List<string>>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).DependsOn,
			Setter = delegate(object obj, List<string>? value)
			{
				((ProjectTask)obj).DependsOn = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "DependsOn",
			JsonPropertyName = "depends_on",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("DependsOn", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
		};
		array[16] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo17);
		array[16].IsGetNullable = false;
		array[16].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo18 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Deliverable,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Deliverable = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Deliverable",
			JsonPropertyName = "deliverable",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Deliverable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[17] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo18);
		JsonPropertyInfoValues<string> propertyInfo19 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(ProjectTask),
			Converter = null,
			Getter = (object obj) => ((ProjectTask)obj).Gate,
			Setter = delegate(object obj, string? value)
			{
				((ProjectTask)obj).Gate = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Gate",
			JsonPropertyName = "gate",
			AttributeProviderFactory = () => typeof(ProjectTask).GetProperty("Gate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[18] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo19);
		return array;
	}

	private void ProjectTaskSerializeHandler(Utf8JsonWriter writer, ProjectTask? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_id, value.Id);
		writer.WriteString(PropName_title, value.Title);
		writer.WriteString(PropName_assignee, value.Assignee);
		writer.WriteString(PropName_status, value.Status);
		writer.WriteString(PropName_update_time, value.UpdateTime);
		writer.WriteString(PropName_result, value.Result);
		writer.WriteString(PropName_priority, value.Priority);
		writer.WriteString(PropName_parent_id, value.ParentId);
		writer.WriteString(PropName_goal_id, value.GoalId);
		writer.WriteString(PropName_checked_out_by, value.CheckedOutBy);
		writer.WriteString(PropName_checked_out_at, value.CheckedOutAt);
		writer.WriteString(PropName_blocked_reason, value.BlockedReason);
		writer.WriteBoolean(PropName_review_required, value.ReviewRequired);
		writer.WritePropertyName(PropName_comments);
		ListTaskCommentSerializeHandler(writer, value.Comments);
		writer.WriteString(PropName_context_summary, value.ContextSummary);
		writer.WriteString(PropName_phase, value.Phase);
		writer.WritePropertyName(PropName_depends_on);
		ListStringSerializeHandler(writer, value.DependsOn);
		writer.WriteString(PropName_deliverable, value.Deliverable);
		writer.WriteString(PropName_gate, value.Gate);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<RoutineAlertPayload> Create_RoutineAlertPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RoutineAlertPayload> jsonTypeInfo))
		{
			JsonObjectInfoValues<RoutineAlertPayload> objectInfo = new JsonObjectInfoValues<RoutineAlertPayload>
			{
				ObjectCreator = () => new RoutineAlertPayload(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => RoutineAlertPayloadPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(RoutineAlertPayload).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = RoutineAlertPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] RoutineAlertPayloadPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[9];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).Type,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).Type = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Type",
			JsonPropertyName = "type",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).RoutineId,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).RoutineId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RoutineId",
			JsonPropertyName = "routine_id",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("RoutineId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).RoutineName,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).RoutineName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RoutineName",
			JsonPropertyName = "routine_name",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("RoutineName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).Employee,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).Employee = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Employee",
			JsonPropertyName = "employee",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("Employee", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<int> propertyInfo5 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).ConsecutiveFailures,
			Setter = delegate(object obj, int value)
			{
				((RoutineAlertPayload)obj).ConsecutiveFailures = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ConsecutiveFailures",
			JsonPropertyName = "consecutive_failures",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("ConsecutiveFailures", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).AlertLevel,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).AlertLevel = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AlertLevel",
			JsonPropertyName = "alert_level",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("AlertLevel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).LastAlertAt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).LastAlertAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastAlertAt",
			JsonPropertyName = "last_alert_at",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("LastAlertAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).LastSeenAt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).LastSeenAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastSeenAt",
			JsonPropertyName = "last_seen_at",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("LastSeenAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineAlertPayload),
			Converter = null,
			Getter = (object obj) => ((RoutineAlertPayload)obj).Message,
			Setter = delegate(object obj, string? value)
			{
				((RoutineAlertPayload)obj).Message = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Message",
			JsonPropertyName = "message",
			AttributeProviderFactory = () => typeof(RoutineAlertPayload).GetProperty("Message", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		array[8].IsGetNullable = false;
		array[8].IsSetNullable = false;
		return array;
	}

	private void RoutineAlertPayloadSerializeHandler(Utf8JsonWriter writer, RoutineAlertPayload? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_type, value.Type);
		writer.WriteString(PropName_routine_id, value.RoutineId);
		writer.WriteString(PropName_routine_name, value.RoutineName);
		writer.WriteString(PropName_employee, value.Employee);
		writer.WriteNumber(PropName_consecutive_failures, value.ConsecutiveFailures);
		writer.WriteString(PropName_alert_level, value.AlertLevel);
		writer.WriteString(PropName_last_alert_at, value.LastAlertAt);
		writer.WriteString(PropName_last_seen_at, value.LastSeenAt);
		writer.WriteString(PropName_message, value.Message);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<RoutineJob> Create_RoutineJob(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RoutineJob> jsonTypeInfo))
		{
			JsonObjectInfoValues<RoutineJob> objectInfo = new JsonObjectInfoValues<RoutineJob>
			{
				ObjectCreator = () => new RoutineJob(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => RoutineJobPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(RoutineJob).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = RoutineJobSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] RoutineJobPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[13];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).Id,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).Name,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).Name = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Name",
			JsonPropertyName = "name",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).Employee,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).Employee = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Employee",
			JsonPropertyName = "employee",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("Employee", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<bool> propertyInfo4 = new JsonPropertyInfoValues<bool>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).Enabled,
			Setter = delegate(object obj, bool value)
			{
				((RoutineJob)obj).Enabled = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Enabled",
			JsonPropertyName = "enabled",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("Enabled", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).Prompt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).Prompt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Prompt",
			JsonPropertyName = "prompt",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("Prompt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<RoutineTrigger> propertyInfo6 = new JsonPropertyInfoValues<RoutineTrigger>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).Trigger,
			Setter = delegate(object obj, RoutineTrigger? value)
			{
				((RoutineJob)obj).Trigger = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Trigger",
			JsonPropertyName = "trigger",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("Trigger", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(RoutineTrigger), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		array[5].IsGetNullable = false;
		array[5].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).NextRunAt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).NextRunAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "NextRunAt",
			JsonPropertyName = "next_run_at",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("NextRunAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).LastRunAt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).LastRunAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastRunAt",
			JsonPropertyName = "last_run_at",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("LastRunAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<int> propertyInfo9 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).MaxRetries,
			Setter = delegate(object obj, int value)
			{
				((RoutineJob)obj).MaxRetries = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "MaxRetries",
			JsonPropertyName = "max_retries",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("MaxRetries", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		JsonPropertyInfoValues<int> propertyInfo10 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).RetryBackoffMinutes,
			Setter = delegate(object obj, int value)
			{
				((RoutineJob)obj).RetryBackoffMinutes = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RetryBackoffMinutes",
			JsonPropertyName = "retry_backoff_minutes",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("RetryBackoffMinutes", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
		JsonPropertyInfoValues<int> propertyInfo11 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).ConsecutiveFailures,
			Setter = delegate(object obj, int value)
			{
				((RoutineJob)obj).ConsecutiveFailures = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ConsecutiveFailures",
			JsonPropertyName = "consecutive_failures",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("ConsecutiveFailures", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
		JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).LastAlertAt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).LastAlertAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "LastAlertAt",
			JsonPropertyName = "last_alert_at",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("LastAlertAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
		JsonPropertyInfoValues<string> propertyInfo13 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineJob),
			Converter = null,
			Getter = (object obj) => ((RoutineJob)obj).AlertLevel,
			Setter = delegate(object obj, string? value)
			{
				((RoutineJob)obj).AlertLevel = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "AlertLevel",
			JsonPropertyName = "alert_level",
			AttributeProviderFactory = () => typeof(RoutineJob).GetProperty("AlertLevel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
		return array;
	}

	private void RoutineJobSerializeHandler(Utf8JsonWriter writer, RoutineJob? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_id, value.Id);
		writer.WriteString(PropName_name, value.Name);
		writer.WriteString(PropName_employee, value.Employee);
		writer.WriteBoolean(PropName_enabled, value.Enabled);
		writer.WriteString(PropName_prompt, value.Prompt);
		writer.WritePropertyName(PropName_trigger);
		RoutineTriggerSerializeHandler(writer, value.Trigger);
		writer.WriteString(PropName_next_run_at, value.NextRunAt);
		writer.WriteString(PropName_last_run_at, value.LastRunAt);
		writer.WriteNumber(PropName_max_retries, value.MaxRetries);
		writer.WriteNumber(PropName_retry_backoff_minutes, value.RetryBackoffMinutes);
		writer.WriteNumber(PropName_consecutive_failures, value.ConsecutiveFailures);
		writer.WriteString(PropName_last_alert_at, value.LastAlertAt);
		writer.WriteString(PropName_alert_level, value.AlertLevel);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<RoutineRunRecord> Create_RoutineRunRecord(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RoutineRunRecord> jsonTypeInfo))
		{
			JsonObjectInfoValues<RoutineRunRecord> objectInfo = new JsonObjectInfoValues<RoutineRunRecord>
			{
				ObjectCreator = () => new RoutineRunRecord(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => RoutineRunRecordPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(RoutineRunRecord).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = RoutineRunRecordSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] RoutineRunRecordPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[9];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).Id,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).Id = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Id",
			JsonPropertyName = "id",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).RoutineId,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).RoutineId = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RoutineId",
			JsonPropertyName = "routine_id",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("RoutineId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).RoutineName,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).RoutineName = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "RoutineName",
			JsonPropertyName = "routine_name",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("RoutineName", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).Employee,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).Employee = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Employee",
			JsonPropertyName = "employee",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("Employee", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
		array[3].IsGetNullable = false;
		array[3].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).StartedAt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).StartedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "StartedAt",
			JsonPropertyName = "started_at",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("StartedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
		array[4].IsGetNullable = false;
		array[4].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).FinishedAt,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).FinishedAt = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "FinishedAt",
			JsonPropertyName = "finished_at",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("FinishedAt", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
		JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).Status,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).Status = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Status",
			JsonPropertyName = "status",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
		array[6].IsGetNullable = false;
		array[6].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).Summary,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).Summary = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Summary",
			JsonPropertyName = "summary",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("Summary", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
		JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineRunRecord),
			Converter = null,
			Getter = (object obj) => ((RoutineRunRecord)obj).ErrorMessage,
			Setter = delegate(object obj, string? value)
			{
				((RoutineRunRecord)obj).ErrorMessage = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "ErrorMessage",
			JsonPropertyName = "error_message",
			AttributeProviderFactory = () => typeof(RoutineRunRecord).GetProperty("ErrorMessage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
		return array;
	}

	private void RoutineRunRecordSerializeHandler(Utf8JsonWriter writer, RoutineRunRecord? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_id, value.Id);
		writer.WriteString(PropName_routine_id, value.RoutineId);
		writer.WriteString(PropName_routine_name, value.RoutineName);
		writer.WriteString(PropName_employee, value.Employee);
		writer.WriteString(PropName_started_at, value.StartedAt);
		writer.WriteString(PropName_finished_at, value.FinishedAt);
		writer.WriteString(PropName_status, value.Status);
		writer.WriteString(PropName_summary, value.Summary);
		writer.WriteString(PropName_error_message, value.ErrorMessage);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<RoutineTrigger> Create_RoutineTrigger(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RoutineTrigger> jsonTypeInfo))
		{
			JsonObjectInfoValues<RoutineTrigger> objectInfo = new JsonObjectInfoValues<RoutineTrigger>
			{
				ObjectCreator = () => new RoutineTrigger(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => RoutineTriggerPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(RoutineTrigger).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = RoutineTriggerSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] RoutineTriggerPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[3];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineTrigger),
			Converter = null,
			Getter = (object obj) => ((RoutineTrigger)obj).TriggerKind,
			Setter = delegate(object obj, string? value)
			{
				((RoutineTrigger)obj).TriggerKind = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "TriggerKind",
			JsonPropertyName = "trigger_kind",
			AttributeProviderFactory = () => typeof(RoutineTrigger).GetProperty("TriggerKind", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineTrigger),
			Converter = null,
			Getter = (object obj) => ((RoutineTrigger)obj).CronExpression,
			Setter = delegate(object obj, string? value)
			{
				((RoutineTrigger)obj).CronExpression = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "CronExpression",
			JsonPropertyName = "cron_expression",
			AttributeProviderFactory = () => typeof(RoutineTrigger).GetProperty("CronExpression", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(RoutineTrigger),
			Converter = null,
			Getter = (object obj) => ((RoutineTrigger)obj).IntervalMinutes,
			Setter = delegate(object obj, int value)
			{
				((RoutineTrigger)obj).IntervalMinutes = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "IntervalMinutes",
			JsonPropertyName = "interval_minutes",
			AttributeProviderFactory = () => typeof(RoutineTrigger).GetProperty("IntervalMinutes", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		return array;
	}

	private void RoutineTriggerSerializeHandler(Utf8JsonWriter writer, RoutineTrigger? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_trigger_kind, value.TriggerKind);
		writer.WriteString(PropName_cron_expression, value.CronExpression);
		writer.WriteNumber(PropName_interval_minutes, value.IntervalMinutes);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<TaskComment> Create_TaskComment(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<TaskComment> jsonTypeInfo))
		{
			JsonObjectInfoValues<TaskComment> objectInfo = new JsonObjectInfoValues<TaskComment>
			{
				ObjectCreator = () => new TaskComment(),
				ObjectWithParameterizedConstructorCreator = null,
				PropertyMetadataInitializer = (JsonSerializerContext _) => TaskCommentPropInit(options),
				ConstructorParameterMetadataInitializer = null,
				ConstructorAttributeProviderFactory = () => typeof(TaskComment).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
				SerializeHandler = TaskCommentSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private static JsonPropertyInfo[] TaskCommentPropInit(JsonSerializerOptions options)
	{
		JsonPropertyInfo[] array = new JsonPropertyInfo[3];
		JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(TaskComment),
			Converter = null,
			Getter = (object obj) => ((TaskComment)obj).Author,
			Setter = delegate(object obj, string? value)
			{
				((TaskComment)obj).Author = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Author",
			JsonPropertyName = "author",
			AttributeProviderFactory = () => typeof(TaskComment).GetProperty("Author", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
		array[0].IsGetNullable = false;
		array[0].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(TaskComment),
			Converter = null,
			Getter = (object obj) => ((TaskComment)obj).Content,
			Setter = delegate(object obj, string? value)
			{
				((TaskComment)obj).Content = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Content",
			JsonPropertyName = "content",
			AttributeProviderFactory = () => typeof(TaskComment).GetProperty("Content", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
		array[1].IsGetNullable = false;
		array[1].IsSetNullable = false;
		JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
		{
			IsProperty = true,
			IsPublic = true,
			IsVirtual = false,
			DeclaringType = typeof(TaskComment),
			Converter = null,
			Getter = (object obj) => ((TaskComment)obj).Timestamp,
			Setter = delegate(object obj, string? value)
			{
				((TaskComment)obj).Timestamp = value;
			},
			IgnoreCondition = null,
			HasJsonInclude = false,
			IsExtensionData = false,
			NumberHandling = null,
			PropertyName = "Timestamp",
			JsonPropertyName = "timestamp",
			AttributeProviderFactory = () => typeof(TaskComment).GetProperty("Timestamp", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
		};
		array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
		array[2].IsGetNullable = false;
		array[2].IsSetNullable = false;
		return array;
	}

	private void TaskCommentSerializeHandler(Utf8JsonWriter writer, TaskComment? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteString(PropName_author, value.Author);
		writer.WriteString(PropName_content, value.Content);
		writer.WriteString(PropName_timestamp, value.Timestamp);
		writer.WriteEndObject();
	}

	private JsonTypeInfo<Dictionary<string, AgentHeartbeatStatus>> Create_DictionaryStringAgentHeartbeatStatus(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Dictionary<string, AgentHeartbeatStatus>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<Dictionary<string, AgentHeartbeatStatus>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, AgentHeartbeatStatus>>
			{
				ObjectCreator = () => new Dictionary<string, AgentHeartbeatStatus>(),
				SerializeHandler = DictionaryStringAgentHeartbeatStatusSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, AgentHeartbeatStatus>, string, AgentHeartbeatStatus>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void DictionaryStringAgentHeartbeatStatusSerializeHandler(Utf8JsonWriter writer, Dictionary<string, AgentHeartbeatStatus>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		foreach (KeyValuePair<string, AgentHeartbeatStatus> item in value)
		{
			writer.WritePropertyName(item.Key);
			AgentHeartbeatStatusSerializeHandler(writer, item.Value);
		}
		writer.WriteEndObject();
	}

	private JsonTypeInfo<Dictionary<string, NodeDiagnosis>> Create_DictionaryStringNodeDiagnosis(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Dictionary<string, NodeDiagnosis>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<Dictionary<string, NodeDiagnosis>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, NodeDiagnosis>>
			{
				ObjectCreator = () => new Dictionary<string, NodeDiagnosis>(),
				SerializeHandler = DictionaryStringNodeDiagnosisSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, NodeDiagnosis>, string, NodeDiagnosis>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void DictionaryStringNodeDiagnosisSerializeHandler(Utf8JsonWriter writer, Dictionary<string, NodeDiagnosis>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		foreach (KeyValuePair<string, NodeDiagnosis> item in value)
		{
			writer.WritePropertyName(item.Key);
			NodeDiagnosisSerializeHandler(writer, item.Value);
		}
		writer.WriteEndObject();
	}

	private JsonTypeInfo<Dictionary<string, NodeInfo>> Create_DictionaryStringNodeInfo(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Dictionary<string, NodeInfo>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<Dictionary<string, NodeInfo>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, NodeInfo>>
			{
				ObjectCreator = () => new Dictionary<string, NodeInfo>(),
				SerializeHandler = DictionaryStringNodeInfoSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, NodeInfo>, string, NodeInfo>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void DictionaryStringNodeInfoSerializeHandler(Utf8JsonWriter writer, Dictionary<string, NodeInfo>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		foreach (KeyValuePair<string, NodeInfo> item in value)
		{
			writer.WritePropertyName(item.Key);
			NodeInfoSerializeHandler(writer, item.Value);
		}
		writer.WriteEndObject();
	}

	private JsonTypeInfo<Dictionary<string, JsonElement>> Create_DictionaryStringJsonElement(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Dictionary<string, JsonElement>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<Dictionary<string, JsonElement>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, JsonElement>>
			{
				ObjectCreator = () => new Dictionary<string, JsonElement>(),
				SerializeHandler = DictionaryStringJsonElementSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, JsonElement>, string, JsonElement>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void DictionaryStringJsonElementSerializeHandler(Utf8JsonWriter writer, Dictionary<string, JsonElement>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		foreach (KeyValuePair<string, JsonElement> item in value)
		{
			writer.WritePropertyName(item.Key);
			JsonSerializer.Serialize(writer, item.Value, JsonElement);
		}
		writer.WriteEndObject();
	}

	private JsonTypeInfo<List<AgentJobRecord>> Create_ListAgentJobRecord(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<AgentJobRecord>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<AgentJobRecord>> collectionInfo = new JsonCollectionInfoValues<List<AgentJobRecord>>
			{
				ObjectCreator = () => new List<AgentJobRecord>(),
				SerializeHandler = ListAgentJobRecordSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<AgentJobRecord>, AgentJobRecord>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListAgentJobRecordSerializeHandler(Utf8JsonWriter writer, List<AgentJobRecord>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			AgentJobRecordSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<AgentNodeClientPayload>> Create_ListAgentNodeClientPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<AgentNodeClientPayload>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<AgentNodeClientPayload>> collectionInfo = new JsonCollectionInfoValues<List<AgentNodeClientPayload>>
			{
				ObjectCreator = () => new List<AgentNodeClientPayload>(),
				SerializeHandler = ListAgentNodeClientPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<AgentNodeClientPayload>, AgentNodeClientPayload>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListAgentNodeClientPayloadSerializeHandler(Utf8JsonWriter writer, List<AgentNodeClientPayload>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			AgentNodeClientPayloadSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<AgentRunPayload>> Create_ListAgentRunPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<AgentRunPayload>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<AgentRunPayload>> collectionInfo = new JsonCollectionInfoValues<List<AgentRunPayload>>
			{
				ObjectCreator = () => new List<AgentRunPayload>(),
				SerializeHandler = ListAgentRunPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<AgentRunPayload>, AgentRunPayload>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListAgentRunPayloadSerializeHandler(Utf8JsonWriter writer, List<AgentRunPayload>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			AgentRunPayloadSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<CompanyGoal>> Create_ListCompanyGoal(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<CompanyGoal>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<CompanyGoal>> collectionInfo = new JsonCollectionInfoValues<List<CompanyGoal>>
			{
				ObjectCreator = () => new List<CompanyGoal>(),
				SerializeHandler = ListCompanyGoalSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<CompanyGoal>, CompanyGoal>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListCompanyGoalSerializeHandler(Utf8JsonWriter writer, List<CompanyGoal>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			CompanyGoalSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<LocalNodeAdminDisabledModel>> Create_ListLocalNodeAdminDisabledModel(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<LocalNodeAdminDisabledModel>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<LocalNodeAdminDisabledModel>> collectionInfo = new JsonCollectionInfoValues<List<LocalNodeAdminDisabledModel>>
			{
				ObjectCreator = () => new List<LocalNodeAdminDisabledModel>(),
				SerializeHandler = ListLocalNodeAdminDisabledModelSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<LocalNodeAdminDisabledModel>, LocalNodeAdminDisabledModel>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListLocalNodeAdminDisabledModelSerializeHandler(Utf8JsonWriter writer, List<LocalNodeAdminDisabledModel>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			LocalNodeAdminDisabledModelSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<LocalNodeModelPayload>> Create_ListLocalNodeModelPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<LocalNodeModelPayload>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<LocalNodeModelPayload>> collectionInfo = new JsonCollectionInfoValues<List<LocalNodeModelPayload>>
			{
				ObjectCreator = () => new List<LocalNodeModelPayload>(),
				SerializeHandler = ListLocalNodeModelPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<LocalNodeModelPayload>, LocalNodeModelPayload>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListLocalNodeModelPayloadSerializeHandler(Utf8JsonWriter writer, List<LocalNodeModelPayload>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			LocalNodeModelPayloadSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<ModelEndpointConfig>> Create_ListModelEndpointConfig(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ModelEndpointConfig>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<ModelEndpointConfig>> collectionInfo = new JsonCollectionInfoValues<List<ModelEndpointConfig>>
			{
				ObjectCreator = () => new List<ModelEndpointConfig>(),
				SerializeHandler = ListModelEndpointConfigSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ModelEndpointConfig>, ModelEndpointConfig>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListModelEndpointConfigSerializeHandler(Utf8JsonWriter writer, List<ModelEndpointConfig>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			ModelEndpointConfigSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<NodeInfoTemplate>> Create_ListNodeInfoTemplate(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<NodeInfoTemplate>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<NodeInfoTemplate>> collectionInfo = new JsonCollectionInfoValues<List<NodeInfoTemplate>>
			{
				ObjectCreator = () => new List<NodeInfoTemplate>(),
				SerializeHandler = ListNodeInfoTemplateSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<NodeInfoTemplate>, NodeInfoTemplate>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListNodeInfoTemplateSerializeHandler(Utf8JsonWriter writer, List<NodeInfoTemplate>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			NodeInfoTemplateSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<OrgNodePayload>> Create_ListOrgNodePayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<OrgNodePayload>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<OrgNodePayload>> collectionInfo = new JsonCollectionInfoValues<List<OrgNodePayload>>
			{
				ObjectCreator = () => new List<OrgNodePayload>(),
				SerializeHandler = ListOrgNodePayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<OrgNodePayload>, OrgNodePayload>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListOrgNodePayloadSerializeHandler(Utf8JsonWriter writer, List<OrgNodePayload>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			OrgNodePayloadSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<ProjectBoard>> Create_ListProjectBoard(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ProjectBoard>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<ProjectBoard>> collectionInfo = new JsonCollectionInfoValues<List<ProjectBoard>>
			{
				ObjectCreator = () => new List<ProjectBoard>(),
				SerializeHandler = ListProjectBoardSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ProjectBoard>, ProjectBoard>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListProjectBoardSerializeHandler(Utf8JsonWriter writer, List<ProjectBoard>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			ProjectBoardSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<ProjectTask>> Create_ListProjectTask(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ProjectTask>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<ProjectTask>> collectionInfo = new JsonCollectionInfoValues<List<ProjectTask>>
			{
				ObjectCreator = () => new List<ProjectTask>(),
				SerializeHandler = ListProjectTaskSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ProjectTask>, ProjectTask>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListProjectTaskSerializeHandler(Utf8JsonWriter writer, List<ProjectTask>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			ProjectTaskSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<RoutineAlertPayload>> Create_ListRoutineAlertPayload(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<RoutineAlertPayload>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<RoutineAlertPayload>> collectionInfo = new JsonCollectionInfoValues<List<RoutineAlertPayload>>
			{
				ObjectCreator = () => new List<RoutineAlertPayload>(),
				SerializeHandler = ListRoutineAlertPayloadSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<RoutineAlertPayload>, RoutineAlertPayload>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListRoutineAlertPayloadSerializeHandler(Utf8JsonWriter writer, List<RoutineAlertPayload>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			RoutineAlertPayloadSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<RoutineJob>> Create_ListRoutineJob(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<RoutineJob>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<RoutineJob>> collectionInfo = new JsonCollectionInfoValues<List<RoutineJob>>
			{
				ObjectCreator = () => new List<RoutineJob>(),
				SerializeHandler = ListRoutineJobSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<RoutineJob>, RoutineJob>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListRoutineJobSerializeHandler(Utf8JsonWriter writer, List<RoutineJob>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			RoutineJobSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<RoutineRunRecord>> Create_ListRoutineRunRecord(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<RoutineRunRecord>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<RoutineRunRecord>> collectionInfo = new JsonCollectionInfoValues<List<RoutineRunRecord>>
			{
				ObjectCreator = () => new List<RoutineRunRecord>(),
				SerializeHandler = ListRoutineRunRecordSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<RoutineRunRecord>, RoutineRunRecord>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListRoutineRunRecordSerializeHandler(Utf8JsonWriter writer, List<RoutineRunRecord>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			RoutineRunRecordSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<TaskComment>> Create_ListTaskComment(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<TaskComment>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<TaskComment>> collectionInfo = new JsonCollectionInfoValues<List<TaskComment>>
			{
				ObjectCreator = () => new List<TaskComment>(),
				SerializeHandler = ListTaskCommentSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<TaskComment>, TaskComment>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListTaskCommentSerializeHandler(Utf8JsonWriter writer, List<TaskComment>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			TaskCommentSerializeHandler(writer, value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<JsonElement>> Create_ListJsonElement(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<JsonElement>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<JsonElement>> collectionInfo = new JsonCollectionInfoValues<List<JsonElement>>
			{
				ObjectCreator = () => new List<JsonElement>(),
				SerializeHandler = ListJsonElementSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<JsonElement>, JsonElement>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListJsonElementSerializeHandler(Utf8JsonWriter writer, List<JsonElement>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			JsonSerializer.Serialize(writer, value[i], JsonElement);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<List<string>> Create_ListString(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<string>> jsonTypeInfo))
		{
			JsonCollectionInfoValues<List<string>> collectionInfo = new JsonCollectionInfoValues<List<string>>
			{
				ObjectCreator = () => new List<string>(),
				SerializeHandler = ListStringSerializeHandler
			};
			jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<string>, string>(options, collectionInfo);
			jsonTypeInfo.NumberHandling = null;
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private void ListStringSerializeHandler(Utf8JsonWriter writer, List<string>? value)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartArray();
		for (int i = 0; i < value.Count; i++)
		{
			writer.WriteStringValue(value[i]);
		}
		writer.WriteEndArray();
	}

	private JsonTypeInfo<Guid> Create_Guid(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Guid> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<Guid>(options, JsonMetadataServices.GuidConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<JsonElement> Create_JsonElement(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<JsonElement> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<JsonElement>(options, JsonMetadataServices.JsonElementConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<JsonElement?> Create_NullableJsonElement(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<JsonElement?> jsonTypeInfo))
		{
			JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<JsonElement>(options);
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<JsonElement?>(options, nullableConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<int> Create_Int32(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<int> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int>(options, JsonMetadataServices.Int32Converter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<long> Create_Int64(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<long> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<long>(options, JsonMetadataServices.Int64Converter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	private JsonTypeInfo<string> Create_String(JsonSerializerOptions options)
	{
		if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<string> jsonTypeInfo))
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<string>(options, JsonMetadataServices.StringConverter);
		}
		jsonTypeInfo.OriginatingResolver = this;
		return jsonTypeInfo;
	}

	public AppJsonContext()
		: base(null)
	{
	}

	public AppJsonContext(JsonSerializerOptions options)
		: base(options)
	{
	}

	private static bool TryGetTypeInfoForRuntimeCustomConverter<TJsonMetadataType>(JsonSerializerOptions options, out JsonTypeInfo<TJsonMetadataType> jsonTypeInfo)
	{
		JsonConverter runtimeConverterForType = GetRuntimeConverterForType(typeof(TJsonMetadataType), options);
		if (runtimeConverterForType != null)
		{
			jsonTypeInfo = JsonMetadataServices.CreateValueInfo<TJsonMetadataType>(options, runtimeConverterForType);
			return true;
		}
		jsonTypeInfo = null;
		return false;
	}

	private static JsonConverter? GetRuntimeConverterForType(Type type, JsonSerializerOptions options)
	{
		for (int i = 0; i < options.Converters.Count; i++)
		{
			JsonConverter jsonConverter = options.Converters[i];
			if (jsonConverter != null && jsonConverter.CanConvert(type))
			{
				return ExpandConverter(type, jsonConverter, options, validateCanConvert: false);
			}
		}
		return null;
	}

	private static JsonConverter ExpandConverter(Type type, JsonConverter converter, JsonSerializerOptions options, bool validateCanConvert = true)
	{
		if (validateCanConvert && !converter.CanConvert(type))
		{
			throw new InvalidOperationException($"The converter '{converter.GetType()}' is not compatible with the type '{type}'.");
		}
		if (converter is JsonConverterFactory jsonConverterFactory)
		{
			converter = jsonConverterFactory.CreateConverter(type, options);
			if (converter == null || converter is JsonConverterFactory)
			{
				throw new InvalidOperationException($"The converter '{jsonConverterFactory.GetType()}' cannot return null or a JsonConverterFactory instance.");
			}
		}
		return converter;
	}

	public override JsonTypeInfo? GetTypeInfo(Type type)
	{
		base.Options.TryGetTypeInfo(type, out JsonTypeInfo typeInfo);
		return typeInfo;
	}

	JsonTypeInfo? IJsonTypeInfoResolver.GetTypeInfo(Type type, JsonSerializerOptions options)
	{
		if (type == typeof(bool))
		{
			return Create_Boolean(options);
		}
		if (type == typeof(decimal))
		{
			return Create_Decimal(options);
		}
		if (type == typeof(decimal?))
		{
			return Create_NullableDecimal(options);
		}
		if (type == typeof(AccountAdminConfigPayload))
		{
			return Create_AccountAdminConfigPayload(options);
		}
		if (type == typeof(AccountAdminConfigResponse))
		{
			return Create_AccountAdminConfigResponse(options);
		}
		if (type == typeof(AccountAvatarUploadRequest))
		{
			return Create_AccountAvatarUploadRequest(options);
		}
		if (type == typeof(AccountProfilePatchRequest))
		{
			return Create_AccountProfilePatchRequest(options);
		}
		if (type == typeof(AgentHealthPayload))
		{
			return Create_AgentHealthPayload(options);
		}
		if (type == typeof(AgentHeartbeatStatus))
		{
			return Create_AgentHeartbeatStatus(options);
		}
		if (type == typeof(AgentJobRecord))
		{
			return Create_AgentJobRecord(options);
		}
		if (type == typeof(AgentNodeBindRequest))
		{
			return Create_AgentNodeBindRequest(options);
		}
		if (type == typeof(AgentNodeClientPackageRequest))
		{
			return Create_AgentNodeClientPackageRequest(options);
		}
		if (type == typeof(AgentNodeClientPayload))
		{
			return Create_AgentNodeClientPayload(options);
		}
		if (type == typeof(AgentNodeHeartbeatRequest))
		{
			return Create_AgentNodeHeartbeatRequest(options);
		}
		if (type == typeof(AgentNodeJobFinishRequest))
		{
			return Create_AgentNodeJobFinishRequest(options);
		}
		if (type == typeof(AgentNodeJobPayload))
		{
			return Create_AgentNodeJobPayload(options);
		}
		if (type == typeof(AgentNodeJobStartRequest))
		{
			return Create_AgentNodeJobStartRequest(options);
		}
		if (type == typeof(AgentNodePollRequest))
		{
			return Create_AgentNodePollRequest(options);
		}
		if (type == typeof(AgentNodePollResponse))
		{
			return Create_AgentNodePollResponse(options);
		}
		if (type == typeof(AgentNodeRegisterRequest))
		{
			return Create_AgentNodeRegisterRequest(options);
		}
		if (type == typeof(AgentProfilePayload))
		{
			return Create_AgentProfilePayload(options);
		}
		if (type == typeof(AgentRunPayload))
		{
			return Create_AgentRunPayload(options);
		}
		if (type == typeof(AgentSupportsPayload))
		{
			return Create_AgentSupportsPayload(options);
		}
		if (type == typeof(AppConfig))
		{
			return Create_AppConfig(options);
		}
		if (type == typeof(AuthCodeRequest))
		{
			return Create_AuthCodeRequest(options);
		}
		if (type == typeof(AuthLoginRequest))
		{
			return Create_AuthLoginRequest(options);
		}
		if (type == typeof(AuthMePayload))
		{
			return Create_AuthMePayload(options);
		}
		if (type == typeof(AuthRegisterRequest))
		{
			return Create_AuthRegisterRequest(options);
		}
		if (type == typeof(AuthResetPasswordRequest))
		{
			return Create_AuthResetPasswordRequest(options);
		}
		if (type == typeof(ChatRequest))
		{
			return Create_ChatRequest(options);
		}
		if (type == typeof(ChatResponse))
		{
			return Create_ChatResponse(options);
		}
		if (type == typeof(CompanyGoal))
		{
			return Create_CompanyGoal(options);
		}
		if (type == typeof(CompanySetupResult))
		{
			return Create_CompanySetupResult(options);
		}
		if (type == typeof(CreateCompanyReq))
		{
			return Create_CreateCompanyReq(options);
		}
		if (type == typeof(LocalNodeAdminConfigPayload))
		{
			return Create_LocalNodeAdminConfigPayload(options);
		}
		if (type == typeof(LocalNodeAdminDisabledModel))
		{
			return Create_LocalNodeAdminDisabledModel(options);
		}
		if (type == typeof(LocalNodeAdminDisableResult))
		{
			return Create_LocalNodeAdminDisableResult(options);
		}
		if (type == typeof(LocalNodeModelPayload))
		{
			return Create_LocalNodeModelPayload(options);
		}
		if (type == typeof(ModelEndpointConfig))
		{
			return Create_ModelEndpointConfig(options);
		}
		if (type == typeof(NodeDiagnosis))
		{
			return Create_NodeDiagnosis(options);
		}
		if (type == typeof(NodeInfo))
		{
			return Create_NodeInfo(options);
		}
		if (type == typeof(NodeInfoTemplate))
		{
			return Create_NodeInfoTemplate(options);
		}
		if (type == typeof(OrgNodePayload))
		{
			return Create_OrgNodePayload(options);
		}
		if (type == typeof(ProjectBoard))
		{
			return Create_ProjectBoard(options);
		}
		if (type == typeof(ProjectTask))
		{
			return Create_ProjectTask(options);
		}
		if (type == typeof(RoutineAlertPayload))
		{
			return Create_RoutineAlertPayload(options);
		}
		if (type == typeof(RoutineJob))
		{
			return Create_RoutineJob(options);
		}
		if (type == typeof(RoutineRunRecord))
		{
			return Create_RoutineRunRecord(options);
		}
		if (type == typeof(RoutineTrigger))
		{
			return Create_RoutineTrigger(options);
		}
		if (type == typeof(TaskComment))
		{
			return Create_TaskComment(options);
		}
		if (type == typeof(Dictionary<string, AgentHeartbeatStatus>))
		{
			return Create_DictionaryStringAgentHeartbeatStatus(options);
		}
		if (type == typeof(Dictionary<string, NodeDiagnosis>))
		{
			return Create_DictionaryStringNodeDiagnosis(options);
		}
		if (type == typeof(Dictionary<string, NodeInfo>))
		{
			return Create_DictionaryStringNodeInfo(options);
		}
		if (type == typeof(Dictionary<string, JsonElement>))
		{
			return Create_DictionaryStringJsonElement(options);
		}
		if (type == typeof(List<AgentJobRecord>))
		{
			return Create_ListAgentJobRecord(options);
		}
		if (type == typeof(List<AgentNodeClientPayload>))
		{
			return Create_ListAgentNodeClientPayload(options);
		}
		if (type == typeof(List<AgentRunPayload>))
		{
			return Create_ListAgentRunPayload(options);
		}
		if (type == typeof(List<CompanyGoal>))
		{
			return Create_ListCompanyGoal(options);
		}
		if (type == typeof(List<LocalNodeAdminDisabledModel>))
		{
			return Create_ListLocalNodeAdminDisabledModel(options);
		}
		if (type == typeof(List<LocalNodeModelPayload>))
		{
			return Create_ListLocalNodeModelPayload(options);
		}
		if (type == typeof(List<ModelEndpointConfig>))
		{
			return Create_ListModelEndpointConfig(options);
		}
		if (type == typeof(List<NodeInfoTemplate>))
		{
			return Create_ListNodeInfoTemplate(options);
		}
		if (type == typeof(List<OrgNodePayload>))
		{
			return Create_ListOrgNodePayload(options);
		}
		if (type == typeof(List<ProjectBoard>))
		{
			return Create_ListProjectBoard(options);
		}
		if (type == typeof(List<ProjectTask>))
		{
			return Create_ListProjectTask(options);
		}
		if (type == typeof(List<RoutineAlertPayload>))
		{
			return Create_ListRoutineAlertPayload(options);
		}
		if (type == typeof(List<RoutineJob>))
		{
			return Create_ListRoutineJob(options);
		}
		if (type == typeof(List<RoutineRunRecord>))
		{
			return Create_ListRoutineRunRecord(options);
		}
		if (type == typeof(List<TaskComment>))
		{
			return Create_ListTaskComment(options);
		}
		if (type == typeof(List<JsonElement>))
		{
			return Create_ListJsonElement(options);
		}
		if (type == typeof(List<string>))
		{
			return Create_ListString(options);
		}
		if (type == typeof(Guid))
		{
			return Create_Guid(options);
		}
		if (type == typeof(JsonElement))
		{
			return Create_JsonElement(options);
		}
		if (type == typeof(JsonElement?))
		{
			return Create_NullableJsonElement(options);
		}
		if (type == typeof(int))
		{
			return Create_Int32(options);
		}
		if (type == typeof(long))
		{
			return Create_Int64(options);
		}
		if (type == typeof(string))
		{
			return Create_String(options);
		}
		return null;
	}
}
