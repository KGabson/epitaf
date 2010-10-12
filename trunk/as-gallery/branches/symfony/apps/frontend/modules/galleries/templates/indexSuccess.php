<h1>Gallerys List</h1>

<table>
  <thead>
    <tr>
      <th>Id</th>
      <th>Title</th>
      <th>Created at</th>
      <th>Updated at</th>
    </tr>
  </thead>
  <tbody>
    <?php foreach ($gallerys as $gallery): ?>
    <tr>
      <td><a href="<?php echo url_for('galleries/show?id='.$gallery->getId()) ?>"><?php echo $gallery->getId() ?></a></td>
      <td><?php echo $gallery->getTitle() ?></td>
      <td><?php echo $gallery->getCreatedAt() ?></td>
      <td><?php echo $gallery->getUpdatedAt() ?></td>
    </tr>
    <?php endforeach; ?>
  </tbody>
</table>

  <a href="<?php echo url_for('galleries/new') ?>">New</a>
