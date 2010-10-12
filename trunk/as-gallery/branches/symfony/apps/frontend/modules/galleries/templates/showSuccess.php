<table>
  <tbody>
    <tr>
      <th>Id:</th>
      <td><?php echo $gallery->getId() ?></td>
    </tr>
    <tr>
      <th>Title:</th>
      <td><?php echo $gallery->getTitle() ?></td>
    </tr>
    <tr>
      <th>Created at:</th>
      <td><?php echo $gallery->getCreatedAt() ?></td>
    </tr>
    <tr>
      <th>Updated at:</th>
      <td><?php echo $gallery->getUpdatedAt() ?></td>
    </tr>
  </tbody>
</table>

<hr />

<a href="<?php echo url_for('galleries/edit?id='.$gallery->getId()) ?>">Edit</a>
&nbsp;
<a href="<?php echo url_for('galleries/index') ?>">List</a>
