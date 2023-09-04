import React, { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Button, Table } from "@mantine/core";
import { useMufredatlarQuery } from "../features/apiSlice"


const MufredatList = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const { data: mufredatlar, isError: error } = useMufredatlarQuery();

  useEffect(() => {
    dispatch(fetchAllUsers()).unwrap();
  }, []);

  const data = mufredatlar?.map((data) => (
    <tr key={data.id}>
      <td>{data.id}</td>
      <td>
        <Link to={`/new-mufredat/${data.id}`}>{data.name}</Link>
      </td>
      <td>
        <Link to={`/mufredat-lessons/${data.id}`}>Göster</Link>
      </td>
    </tr>
  ));

  return (
    <div>
      <Button onClick={() => navigate("/new-mufredat")}>Yeni Müfredat Ekle</Button>
      <br />
      <br />
      {status === "pending" ? (
        <h1>Fetching...</h1>
      ) : error ? (
        error
      ) : (
        <Table striped highlightOnHover withBorder withColumnBorders>
          <thead>
            <tr>
              <th>ID</th>
              <th>Adı</th>
              <th>Ders Listesi</th>
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default MufredatList;
