import React, { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { fetchAllUsers } from "../features/user/userSlice";
import { Button, Table } from "@mantine/core";
import {useStudentsQuery} from "../features/apiSlice"


const Students = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const { data:users,isSuccess:status, isError:error } = useStudentsQuery();

  useEffect(() => {
    dispatch(fetchAllUsers()).unwrap();
  }, []);

  const data = users?.map((user) => (
    <tr key={user.id}>
      <td>{user.id}</td>
      <td>
        <Link to={`/students/${user.id}`}>{user.name}</Link>
      </td>
      <td>
        <Link to={`/registered-lessons/${user.id}`}>Göster</Link>
      </td>
    </tr>
  ));

  return (
    <div>
      <Button onClick={()=>navigate("/new-user")}>Yeni Öğrenci Ekle</Button>
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
              <th>Ad Soyad</th>
              <th>Aldığı Dersler</th>
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default Students;
