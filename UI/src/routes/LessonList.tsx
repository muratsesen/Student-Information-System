import React, { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../app/hooks";
import { useLessonsQuery } from "../features/apiSlice";
import { Button, Table } from "@mantine/core";

const LessonList = () => {
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const { data: lessons, isSuccess: status, isError: error } = useLessonsQuery();

  useEffect(() => {
  }, []);

  const data = lessons?.map((lesson) => (
    <tr key={lesson.id}>
      <td>{lesson.id}</td>
      <td>
        <Link to={`/new-lesson/${lesson.id}`}>{lesson.name}</Link>
      </td>
      <td>{lesson.code}</td>
      <td>{lesson.credit}</td>
      <td>{lesson.status ? "Aktif" : "Pasif"}</td>
    </tr>
  ));

  return (
    <div>
      <Button onClick={() => navigate("/new-lesson")}>Yeni Ders Ekle</Button>
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
              <th>Kodu</th>
              <th>Kredi</th>
              <th>Durumu</th>
            </tr>
          </thead>
          <tbody>{data}</tbody>
        </Table>
      )}
    </div>
  );
};

export default LessonList;
