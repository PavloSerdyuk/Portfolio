import React, { useEffect, useState } from "react";
import { AgGridColumn, AgGridReact } from "ag-grid-react";
import { Button } from "shards-react";

const Representation = () => {
  const [gridApi, setGridApi] = useState(null);
  const [gridAssignedApi, setAssignedGridApi] = useState(null);
  const [gridColumnApi, setGridColumnApi] = useState(null);
  const [rowData] = useState(null);
  const [rowAssignedData] = useState(null);
  const [selectedRepresentations, selectRepresentations] = useState(null);
  const [selectedRepresentationToDelete, selectRepresentationToDelete] =
    useState(null);

  const getToken = () => {
    let token = localStorage.getItem("token");
    if (token) {
      token = token.replace(/^"(.*)"$/, "$1");
      return token;
    }
    return;
  };

  const authHeader = () => {
    return {
      "Content-Type": "application/json",
      Authorization: `Bearer ${getToken()}`,
    };
  };

  const onGridReadyAvailable = (params) => {
    setGridApi(params.api);
    setGridColumnApi(params.columnApi);

    const updateData = (data) => params.api.setRowData(data);

    fetch("https://localhost:44349/api/representation/available", {
      headers: authHeader(),
      credentials: "include",
    })
      .then((resp) => resp.json())
      .then((data) => {
        return updateData(data || []);
      });
  };

  const addItemsToAvailable = (gridToChange, representation) => {
    const res = gridToChange.applyTransaction({
      add: [representation],
      addIndex: 1,
    });
  };

  const onGridReadyAssigned = (params) => {
    setAssignedGridApi(params.api);
    setGridColumnApi(params.columnApi);

    const updateData = (data) => params.api.setRowData(data);

    fetch("https://localhost:44349/api/representation/assigned", {
      headers: authHeader(),
      credentials: "include",
    })
      .then((resp) => resp.json())
      .then((data) => {
        return updateData(data || []);
      });
  };

  const onAvailableSelectionChanged = () => {
    const selectedRows = gridApi.getSelectedRows();
    const row = selectedRows.length === 1 ? selectedRows[0] : "";
    selectRepresentations(row);
  };

  const onAssignedSelectionChanged = () => {
    const selectedRows = gridAssignedApi.getSelectedRows();
    const row = selectedRows.length === 1 ? selectedRows[0] : "";
    selectRepresentationToDelete(row);
  };

  const onAssignRepresentation = () => {
    const representationId = selectedRepresentations?.id;
    const selectedData = gridApi.getSelectedRows();
    if (selectedData == null || selectedData.length === 0) {
      return;
    }

    fetch(
      `https://localhost:44349/api/representations/assign/${representationId}`,
      {
        method: "PUT",
        headers: authHeader(),
        credentials: "include",
      }
    )
      .then((resp) => resp.json())
      .then((data) => {
        addItemsToAvailable(gridAssignedApi, data);
        gridApi.applyTransaction({ remove: selectedData });
      });
  };

  const onDeleteAssignedRepresentation = () => {
    const representationId = selectedRepresentationToDelete?.id;
    const selectedData = gridAssignedApi.getSelectedRows();

    if (selectedData == null || selectedData.length === 0) {
      return;
    }

    fetch(
      `https://localhost:44349/api/representations/delete/assiggned/${representationId}`,
      {
        method: "DELETE",
        headers: authHeader(),
        credentials: "include",
      }
    )
      .then((resp) => resp.json())
      .then((data) => {
        addItemsToAvailable(gridApi, data);
        gridAssignedApi.applyTransaction({ remove: selectedData });
      });
  };

  return (
    <div className="ag-theme-alpine" style={{ height: "auto", width: "auto" }}>
      <h3 style={{ textAlign: "center" }}>Available representation</h3>
      <div style={{ height: 300, width: "auto" }}>
        <AgGridReact
          defaultColDef={{
            flex: 1,
            minWidth: 100,
          }}
          rowSelection={"single"}
          onGridReady={onGridReadyAvailable}
          onSelectionChanged={onAvailableSelectionChanged}
          rowData={rowData}
        >
          <AgGridColumn field="description" minWidth={250} />
          <AgGridColumn field="startTime" minWidth={150} />
          <AgGridColumn field="endTime" minWidth={150} />
          <AgGridColumn
            field="firstName"
            minWidth={150}
            valueGetter={(params) => {
              return params.data?.speaker?.firstName;
            }}
          />
          <AgGridColumn
            field="lastName"
            minWidth={150}
            valueGetter={(params) => {
              return params.data?.speaker?.lastName;
            }}
          />
        </AgGridReact>
      </div>

      <div
        style={{
          width: "auto",
          display: "flex",
          justifyContent: "center",
          margin: "15px",
        }}
      >
        <Button onClick={onAssignRepresentation}>
          Assign to new representation
        </Button>
      </div>

      <h3 style={{ textAlign: "center" }}>Assigned representation</h3>
      <div style={{ height: 300, width: "auto" }}>
        <AgGridReact
          defaultColDef={{
            flex: 1,
            minWidth: 100,
          }}
          onGridReady={onGridReadyAssigned}
          rowData={rowAssignedData}
          rowSelection={"single"}
          onSelectionChanged={onAssignedSelectionChanged}
        >
          <AgGridColumn field="description" minWidth={250} />
          <AgGridColumn field="startTime" minWidth={150} />
          <AgGridColumn field="endTime" minWidth={150} />
          <AgGridColumn
            field="firstName"
            minWidth={150}
            valueGetter={(params) => {
              return params.data?.speaker?.firstName;
            }}
          />
          <AgGridColumn
            field="lastName"
            minWidth={150}
            valueGetter={(params) => {
              return params.data?.speaker?.lastName;
            }}
          />
        </AgGridReact>
      </div>

      <div
        style={{
          width: "auto",
          display: "flex",
          justifyContent: "center",
          margin: "50px",
        }}
      >
        <Button theme="danger" onClick={onDeleteAssignedRepresentation}>
          Assign to new representation
        </Button>
      </div>
    </div>
  );
};
export default Representation;
