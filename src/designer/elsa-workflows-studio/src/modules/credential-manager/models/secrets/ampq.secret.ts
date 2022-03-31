import { Secret } from "../secret.model";

export const Ampq: Secret = {
  category: "AMPQ",
  customAttributes: {},
  description: "AMPQ connection data",
  displayName: "AMPQ secret",
  inputProperties: [
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Hostname",
      name: "hostname",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Port",
      name: "port",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.Int64",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "User",
      name: "user",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Password",
      name: "password",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Transport Type",
      name: "transport_type",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    }
  ],
  properties: [
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Hostname",
      name: "hostname",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Port",
      name: "port",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.Int64",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "User",
      name: "user",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Password",
      name: "password",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    },
    {
      considerValuesAsOutcomes: false,
      disableWorkflowProviderSelection: false,
      isBrowsable: true,
      isDesignerCritical: false,
      isReadOnly: false,
      label: "Transport Type",
      name: "transport_type",
      order: 0,
      supportedSyntaxes: ["JavaScript", "Liquid"],
      type: "System.String",
      uiHint: "single-line",
    }
  ],
  type: "AMPQ"
}